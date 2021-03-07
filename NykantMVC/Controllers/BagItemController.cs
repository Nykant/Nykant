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
            int bagItemQuantity = HttpContext.Session.Get<int>(BagItemAmountKey);
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
                    var response = await DeleteRequest($"/BagItem/DeleteBagItem/{bagItem.Subject}/{bagItem.ProductId}");

                    if (response.IsSuccessStatusCode)
                    {
                        bagItemQuantity -= 1;
                        HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                        return RedirectToAction("Details", "Bag");
                    }
                    return Content("Failed");
                }
                else
                {
                    var response = await PatchRequest("/BagItem/UpdateBagItem", bagItem);

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
                                {
                                    bagItems.RemoveAt(i);
                                    bagItemQuantity -= 1;
                                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                                }
                                break;

                            case 2:
                                bagItems[i].Quantity -= 1;
                                if (bagItems[i].Quantity <= 0)
                                {
                                    bagItems.RemoveAt(i);
                                    bagItemQuantity -= 1;
                                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                                }

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
            int bagItemQuantity = HttpContext.Session.Get<int>(BagItemAmountKey);

            if (productQuantity <= 0)
            {
                return RedirectToAction("Details", "Product", new { id = productVM.Product.Id });
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
                if (!bagItemExists)
                {
                    bagItems.Add(bagItem);
                    bagItemQuantity += 1;
                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                }

                HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                return RedirectToAction("Details", "Product", new { id = bagItem.ProductId, itemAdded = true });
            }
            else
            {
                bagItem.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                var json = await GetRequest($"/BagItem/GetBagItems/{bagItem.Subject}");
                List<BagItem> bagItems = JsonConvert.DeserializeObject<List<BagItem>>(json);

                if (BagItemExists(bagItems, bagItem))
                {
                    var bagItemDb = GetBagItem(bagItems, bagItem);
                    bagItemDb.Quantity += productQuantity;
                    var response = await PatchRequest("/BagItem/UpdateBagItem", bagItemDb);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Details", "Product", new { id = bagItem.ProductId, itemAdded = true });
                    }
                    else
                    {
                        return RedirectToAction("Details", "Product", new { id = productVM.Product.Id });
                    }
                }
                else
                {
                    var response = await PostRequest("/BagItem/PostBagItem", bagItem);
                    if (response.IsSuccessStatusCode)
                    {
                        bagItemQuantity += 1;
                        HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                        return RedirectToAction("Details", "Product", new { id = bagItem.ProductId, itemAdded = true });
                    }
                    else
                    {
                        return RedirectToAction("Details", "Product", new { id = productVM.Product.Id });
                    }
                }
            }
        }

        private bool BagItemExists(List<BagItem> list, BagItem bagItem)
        {
            foreach(var item in list)
            {
                if(item.ProductId == bagItem.ProductId && item.Subject == bagItem.Subject)
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
