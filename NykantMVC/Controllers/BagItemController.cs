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

        public async Task<IActionResult> UpdateBagItem(BagItem bagItem, int selection)
        {
            if (User.Identity.IsAuthenticated)
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

                if(bagItem.Quantity <= 0)
                {
                    var response = await PatchRequest("/BagItem/UpdateBagItem", bagItem);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Bag");
                    }
                    return Content("Failed");
                }
                else
                {
                    var response = await DeleteRequest($"/BagItem/DeleteBagItem/{bagItem.Subject}/{bagItem.ProductId}");

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Bag");
                    }
                    return Content("Failed");
                }

            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

                for(int i = 0; i < bagItems.Count(); i++)
                {
                    if(bagItems[i].ProductId == bagItem.ProductId)
                    {
                        switch (selection)
                        {
                            case 1:
                                bagItems[i].Quantity += 1;
                                if (bagItems[i].Quantity <= 0)
                                    bagItems.RemoveAt(i);
                                break;
                            case 2:
                                bagItems[i].Quantity -= 1;
                                if (bagItems[i].Quantity <= 0)
                                    bagItems.RemoveAt(i);
                                break;
                        }
                    }
                }
                
                HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                return RedirectToAction("Details", "Bag");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostBagItem(ProductVM productVM, int productQuantity)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            if(productQuantity <= 0)
            {
                return new JsonResult("Item not added, something went wrong");
            };

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
                return new JsonResult("Item added to your bag");
            }
            else
            {
                try
                {
                    bagItem.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                    var response = await PostRequest("/BagItem/PostBagItem", bagItem);
                    if (response.IsSuccessStatusCode)
                    {
                        return new JsonResult("Item added to your bag");
                    }
                    else
                    {
                        return new JsonResult("Item not added, something went wrong");
                    }
                }
                catch(Exception e)
                {
                    return new JsonResult(e.Message);
                }
            }
        }
    }
}
