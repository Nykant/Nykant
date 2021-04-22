using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]

    public class BagItemController : BaseController
    {

        public BagItemController(ILogger<BaseController> logger, IOptions<Urls> urls) : base(logger, urls)
        {
        }

        

        [HttpPost]
        public async Task<IActionResult> PostBagItem(Product product)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            int bagItemQuantity = HttpContext.Session.Get<int>(BagItemAmountKey);

            BagItem bagItem = new BagItem
            {
                ProductId = product.Id,
                Quantity = 1
            };

            if (!isAuthenticated)
            {
                try
                {
                    bagItem.Product = product;
                    List<BagItem> bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                    if (bagItems == default || bagItems == null)
                    {
                        bagItems = new List<BagItem>();
                    }

                    bool bagItemExists = false;
                    foreach (var item in bagItems)
                    {
                        if (item.ProductId == bagItem.ProductId)
                        {
                            bagItemExists = true;
                            item.Quantity += 1;
                        }
                    }
                    if (!bagItemExists)
                    {
                        bagItems.Add(bagItem);
                        bagItemQuantity += 1;
                        HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                    }

                    HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                    return NoContent();
                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }
            }
            else
            {
                bagItem.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                var response = await PostRequest("/BagItem/PostBagItem", bagItem);
                if (response.IsSuccessStatusCode)
                {
                    bagItemQuantity += 1;
                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                    return NoContent();
                }
                else
                {
                    return Content("Fejl, prøv igen.");
                }
            }
        }

        private bool BagItemExists(List<BagItem> list, BagItem bagItem)
        {
            foreach (var item in list)
            {
                if (item.ProductId == bagItem.ProductId && item.Subject == bagItem.Subject)
                {
                    return true;
                }
            }
            return false;
        }
        private BagItem GetBagItem(List<BagItem> list, BagItem bagItem)
        {
            foreach (var item in list)
            {
                if (item.ProductId == bagItem.ProductId && item.Subject == bagItem.Subject)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
