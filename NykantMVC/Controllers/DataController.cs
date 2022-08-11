using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Friends;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class DataController : BaseController
    {
        public DataController(ILogger<DataController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var json = await GetRequest("/Image/GetImages");
            var images = new List<Image>(); 
            if (json != null)
            {
                images = JsonConvert.DeserializeObject<List<Image>>(json);
            }
            json = await GetRequest("/Color/GetColors");
            var colors = new List<Color>(); 
            if (json != null)
            {
                colors = JsonConvert.DeserializeObject<List<Color>>(json);
            }
            json = await GetRequest("/Length/GetLengths");
            var lengths = new List<ProductLength>(); 
            if (json != null)
            {
                lengths = JsonConvert.DeserializeObject<List<ProductLength>>(json);
            }

            var vm = new DataVM() { Colors = colors, Images = images, Lengths = lengths };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> UploadData()
        {
            try
            {
                var json = await GetRequest("/Product/GetProductsWithNothing");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                var images = ImageHelper.GetImages();
                var imageList = new List<ImageFile>();
                for (int i = 0; i < images.Length; i++)
                {
                    var s = images[i].Split(@"\");
                    var name = s[s.Length - 1];
                    s = name.Split('.');
                    name = s[0];
                    var chars = name.ToCharArray();
                    var endSub = chars.Length - 4;
                    var type = name.Substring(endSub);
                    name = name.Substring(0, endSub);
                    imageList.Add(new ImageFile { Path = images[i], Name = name, Type = type });
                }

                var newImageList = new List<Image>();

                //New Images
                foreach (var img in imageList)
                {
                    var split = img.Name.Split('-');

                    var itemName = split[0];

                    var itemOil = "";
                    if (split.Length == 2)
                    {
                        itemOil = split[1];
                    }
                    else
                    {
                        if (!split[2].Contains("cm"))
                        {
                            itemOil = split[2];
                        }
                        else
                        {
                            itemOil = split[1];
                        }
                    }

                    switch (itemName)
                    {
                        case "Skrivebord":
                            itemName = "Egetræsbord";
                            break;
                        case "Entrebænk":
                            itemName = "Egetræsbænk";
                            break;
                        case "Egetræsmøbler":
                            goto skip;
                        default:
                            break;
                    }

                    var newImg = new Image();

                    if (img.Type.Contains("df"))
                    {
                        newImg.ImageType = ImageType.DetailsFullscreen;
                    }
                    else if (img.Type.Contains("db"))
                    {
                        newImg.ImageType = ImageType.DetailsButton;
                    }
                    else if (img.Type.Contains("ds"))
                    {
                        newImg.ImageType = ImageType.DetailsSlide;
                    }
                    else if (img.Type.Contains("ga"))
                    {
                        goto skip;
                        newImg.ImageType = ImageType.Gallery;
                    }
                    else if (img.Type.Contains("co"))
                    {
                        goto skip;
                        newImg.ImageType = ImageType.Color;
                    }
                    else if (img.Type.Contains("ca"))
                    {
                        goto skip;
                        newImg.ImageType = ImageType.Category;
                    }

                    string cm = null;
                    if (split.Length == 3)
                    {
                        if (split[2].Contains("cm"))
                        {
                            cm = split[2].Substring(0, 3);
                            if (cm.Contains("c"))
                            {
                                cm = cm.Substring(0, 2);
                            }
                        }
                    }

                    foreach (var product in products)
                    {
                        var t = product.Title.Split(' ');
                        var title = t[0];
                        if (title.Contains(itemName) && product.Oil == itemOil)
                        {
                            if (cm != null)
                            {
                                if (product.Length != null)
                                {
                                    if (product.Length.Contains(cm))
                                    {
                                        newImg.ProductId = product.Id;
                                        newImg.Alt = product.Title;
                                        break;
                                    }
                                    else
                                    {
                                        goto next;
                                    }
                                }
                            }
                            newImg.ProductId = product.Id;
                            newImg.Alt = product.Title;
                            break;
                        }
                        next:;
                    }

                    newImg.Path = img.Path;

                    newImg.Source = img.Path.Substring(10);

                    if (newImg.ImageType == ImageType.DetailsSlide)
                    {
                        newImg.Source2 = newImg.Source.Replace("ds", "df");
                    }

                    newImageList.Add(newImg);

                    //else if (newImg.ImageType == ImageType.Color)
                    //{
                    //    switch (itemOil)
                    //    {
                    //        case "Naturolie":
                    //            newColor.EColor = EColor.Nature;
                    //            break;
                    //        case "Sortolie":
                    //            newColor.EColor = EColor.Black;
                    //            break;
                    //        case "Hvidolie":
                    //            newColor.EColor = EColor.White;
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //    newColorList.Add(newColor);
                    //}
                    skip:;
                    
                }

                var newColorList = new List<Color>();

                //New Colors
                foreach (var img in imageList)
                {
                    var split = img.Name.Split('-');

                    var itemName = split[0];

                    var itemOil = "";
                    if (split.Length == 2)
                    {
                        itemOil = split[1];
                    }
                    else
                    {
                        if (!split[2].Contains("cm"))
                        {
                            itemOil = split[2];
                        }
                        else
                        {
                            itemOil = split[1];
                        }
                    }

                    switch (itemName)
                    {
                        case "Skrivebord":
                            itemName = "Egetræsbord";
                            break;
                        case "Entrebænk":
                            itemName = "Egetræsbænk";
                            break;
                        default:
                            break;
                    }

                    if (img.Type.Contains("df"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("db"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("ds"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("ga"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("ca"))
                    {
                        goto skip;
                    }

                    string cm = null;
                    if (split.Length == 3)
                    {
                        if (split[2].Contains("cm"))
                        {
                            cm = split[2].Substring(0, 3);
                            if (cm.Contains("c"))
                            {
                                cm = cm.Substring(0, 2);
                            }
                        }
                    }

                    foreach (var product in products)
                    {
                        var t = product.Title.Split(' ');
                        var title = t[0];
                        if (title.Contains(itemName) && product.Oil.Contains(itemOil))
                        {
                            var oilList = new List<string>()
                            {
                                "Naturolie",
                                "Sortolie",
                                "Hvidolie"
                            };

                            if (cm != null)
                            {
                                if (product.Length != null)
                                {
                                    if (product.Length.Contains(cm))
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            var newColor = new Color();
                                            var sourceProduct = products.FirstOrDefault(x => x.Oil == oilList[i] && x.Title.Contains(itemName) && x.Length.Contains(cm));
                                            newColor.ProductId = sourceProduct.Id;
                                            newColor.ProductSourceId = product.Id;
                                            newColor.ImgSrc = img.Path.Substring(10);
                                            newColor.ProductSourceUrlName = product.UrlName;
                                            newColor.Alt = product.Title;
                                            switch (product.Oil)
                                            {
                                                case "Naturolie":
                                                    newColor.EColor = EColor.Nature;
                                                    break;
                                                case "Sortolie":
                                                    newColor.EColor = EColor.Black;
                                                    break;
                                                case "Hvidolie":
                                                    newColor.EColor = EColor.White;
                                                    break;
                                                default:
                                                    break;
                                            }

                                            newColorList.Add(newColor);
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        goto next;
                                    }
                                }
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                var newColor = new Color();
                                if(itemName == "Egetræsbord" && oilList[i] == "Sortolie")
                                {
                                    goto nexty;
                                }
                                var sourceProduct = products.FirstOrDefault(x => x.Oil == oilList[i] && x.Title.Contains(itemName));
                                newColor.ProductId = sourceProduct.Id;
                                newColor.ProductSourceId = product.Id;
                                newColor.ImgSrc = img.Path.Substring(10);
                                newColor.ProductSourceUrlName = product.UrlName;
                                newColor.Alt = product.Title;
                                switch (product.Oil)
                                {
                                    case "Naturolie":
                                        newColor.EColor = EColor.Nature;
                                        break;
                                    case "Sortolie":
                                        newColor.EColor = EColor.Black;
                                        break;
                                    case "Hvidolie":
                                        newColor.EColor = EColor.White;
                                        break;
                                    default:
                                        break;
                                }

                                newColorList.Add(newColor);

                                nexty:;
                            }
                            break;
                        }
                        next:;
                    }
                    skip:;
                }

                var newLengthList = new List<ProductLength>();

                var benchLengths = new List<string>()
                {
                    "115 cm.",
                    "170 cm."
                };

                var shelfLengths = new List<string>()
                {
                    "40 cm.",
                    "60 cm.",
                    "80 cm.",
                    "100 cm."
                };

                foreach (var product in products)
                {
                    var t = product.Title.Split(' ');
                    var title = t[0];
                    if (product.Length != null)
                    {
                        if (title.Contains("Egetræsbænk"))
                        {
                            for(int i = 0; i < 2; i++)
                            {
                                var refProduct = products.FirstOrDefault(x => x.Title.Contains(title) && x.Oil.Contains(product.Oil) && x.Length == benchLengths[i]);
                                var length = new ProductLength()
                                {
                                    Length = refProduct.Length,
                                     ProductId = product.Id,
                                     ProductReferenceId = refProduct.Id,
                                     ProductReferenceUrlName = refProduct.UrlName
                                };
                                newLengthList.Add(length);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                var refProduct = products.FirstOrDefault(x => x.Title.Contains(title) && x.Oil.Contains(product.Oil) && x.Length == shelfLengths[i]);
                                var length = new ProductLength()
                                {
                                    Length = refProduct.Length,
                                    ProductId = product.Id,
                                    ProductReferenceId = refProduct.Id,
                                    ProductReferenceUrlName = refProduct.UrlName
                                };
                                newLengthList.Add(length);
                            }
                        }
                    }
                }

                var newProductList = new List<Product>();

                foreach (var img in imageList)
                {
                    var source = img.Path.Substring(10);
                    var split = img.Name.Split('-');

                    var itemName = split[0];

                    var itemOil = "";
                    if (split.Length == 2)
                    {
                        itemOil = split[1];
                    }
                    else
                    {
                        if (!split[2].Contains("cm"))
                        {
                            itemOil = split[2];
                        }
                        else
                        {
                            itemOil = split[1];
                        }
                    }

                    switch (itemName)
                    {
                        case "Skrivebord":
                            itemName = "Egetræsbord";
                            break;
                        case "Entrebænk":
                            itemName = "Egetræsbænk";
                            break;
                        default:
                            break;
                    }

                    if (img.Type.Contains("df"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("db"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("ds"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("co"))
                    {
                        goto skip;
                    }
                    else if (img.Type.Contains("ca"))
                    {
                        goto skip;
                    }

                    string cm = null;
                    if (split.Length == 3)
                    {
                        if (split[2].Contains("cm"))
                        {
                            cm = split[2].Substring(0, 3);
                            if (cm.Contains("c"))
                            {
                                cm = cm.Substring(0, 2);
                            }
                        }
                    }


                    bool found = false;
                    if(newProductList.Count > 0)
                    {
                        for (int i = 0; i < newProductList.Count; i++)
                        {
                            var t = newProductList[i].Title.Split(' ');
                            var title = t[0];
                            if (title.Contains(itemName) && newProductList[i].Oil == itemOil)
                            {
                                if (cm != null)
                                {
                                    if (newProductList[i].Length != null)
                                    {
                                        if (newProductList[i].Length.Contains(cm))
                                        {
                                            found = true;
                                            if (img.Type.Contains('2'))
                                            {
                                                newProductList[i].GalleryImage1 = source;
                                            }
                                            else if (img.Type.Contains('1'))
                                            {
                                                newProductList[i].GalleryImage2 = source;
                                            }

                                            break;
                                        }
                                        else
                                        {
                                            goto next;
                                        }
                                    }
                                }
                                found = true;
                                if (img.Type.Contains('2'))
                                {
                                    newProductList[i].GalleryImage1 = source;

                                }
                                else if (img.Type.Contains('1'))
                                {
                                    newProductList[i].GalleryImage2 = source;

                                }
                                break;
                            }
                            next:;
                        }
                    }
                    
                    if (!found)
                    {
                        var newProduct = new Product();
                        foreach (var product in products)
                        {
                            var t = product.Title.Split(' ');
                            var title = t[0];
                            if (title.Contains(itemName) && product.Oil == itemOil)
                            {
                                if (cm != null)
                                {
                                    if (product.Length != null)
                                    {
                                        if (product.Length.Contains(cm))
                                        {
                                            newProduct = product;
                                            newProduct.Alt = product.Title;
                                            if (img.Type.Contains('2'))
                                            {
                                                newProduct.GalleryImage1 = source;
                                                newProductList.Add(newProduct);
                                            }
                                            else if (img.Type.Contains('1'))
                                            {
                                                newProduct.GalleryImage2 = source;
                                                newProductList.Add(newProduct);
                                            }

                                            break;
                                        }
                                        else
                                        {
                                            goto next;
                                        }
                                    }
                                }
                                newProduct = product;
                                newProduct.Alt = product.Title;
                                if (img.Type.Contains('2'))
                                {
                                    newProduct.GalleryImage1 = source;
                                    newProductList.Add(newProduct);
                                }
                                else if (img.Type.Contains('1'))
                                {
                                    newProduct.GalleryImage2 = source;
                                    newProductList.Add(newProduct);
                                }

                                break;
                            }
                            next:;
                        }
                    }

                    //else if (newImg.ImageType == ImageType.Color)
                    //{
                    //    switch (itemOil)
                    //    {
                    //        case "Naturolie":
                    //            newColor.EColor = EColor.Nature;
                    //            break;
                    //        case "Sortolie":
                    //            newColor.EColor = EColor.Black;
                    //            break;
                    //        case "Hvidolie":
                    //            newColor.EColor = EColor.White;
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //    newColorList.Add(newColor);
                    //}
                    skip:;

                }

                var res = await PatchRequest("/Product/UpdateProducts", newProductList);
                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                    return BadRequest($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                }

                res = await PostRequest("/Length/PostLengths", newLengthList);
                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                    return BadRequest($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                }

                res = await PostRequest("/Color/PostColors", newColorList);
                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                    return BadRequest($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                }

                res = await PostRequest("/Image/PostImages", newImageList);
                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                    return BadRequest($"time: {DateTime.Now} - {res.StatusCode}, {res.ReasonPhrase}");
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }
        }
    }
}
