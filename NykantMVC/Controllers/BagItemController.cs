using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class BagItemController : BaseController
    {

        public BagItemController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateBagItem(BagItem bagItem, int? selection)
        {
            if (selection != 0)
            {
                if (selection == 1)
                {
                    bagItem.Quantity += 1;
                }
                else if (selection == 2)
                {
                    bagItem.Quantity -= 1;
                }
            }

            var response = await PatchRequest("/BagItem/UpdateBagItem", bagItem);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Bag");
            }
            return Content("Failed");
        }

        [HttpPost]
        public async Task<IActionResult> PostBagItem(ProductVM productVM, int productQuantity)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            BagItem bagItem = new BagItem
            {
                ProductId = productVM.Product.Id,
                Quantity = productQuantity
            };

            if (!isAuthenticated)
            {
                bagItem.Product = productVM.Product;
                List<BagItem> bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                if (bagItems == default
                    || bagItems == null)
                {
                    bagItems = new List<BagItem>();
                }

                bool bagItemExists = false;
                foreach(var item in bagItems)
                {
                    if(item.ProductId == bagItem.ProductId)
                    {
                        bagItemExists = true;
                        item.Quantity += productQuantity;
                    }
                }
                if(!bagItemExists)
                bagItems.Add(bagItem);

                HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                return Content("Item added to your bag");
            }
            else
            {
                try
                {
                    bagItem.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                    var response = await PostRequest("/BagItem/PostBagItem", bagItem);
                    if (response.IsSuccessStatusCode)
                    {
                        return Content("Item added to your bag");
                    }
                    else
                    {
                        return Content("Item not added, something went wrong");
                    }
                }
                catch(Exception e)
                {
                    return Content(e.Message);
                }
            }
        }
    }
}
