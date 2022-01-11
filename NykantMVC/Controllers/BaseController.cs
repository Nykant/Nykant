using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.XmlModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NykantMVC.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public const string BagSessionKey = "verysecretbagsessionkey";
        public const string CheckoutSessionKey = "verysecretseriouscheckoutsessionkey";
        public const string BagItemAmountKey = "verysecretseriousbagitemsessionkeyspecial";
        public const string ConsentCookieKey = "verysecretseriousconsentsessionkeyspecial";
        public readonly ILogger<BaseController> _logger;
        private readonly Urls _urls;
        private readonly HtmlEncoder htmlEncoder;


        public BaseController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder)
        {
            this.htmlEncoder = htmlEncoder;
            _logger = logger;
            _urls = urls.Value;
        }

        public Customer EncodeCustomer(Customer customer)
        {
            if(customer.Email != null)
            {
                customer.Email = htmlEncoder.Encode(customer.Email);
                if(customer.Phone != null)
                {
                    customer.Phone = htmlEncoder.Encode(customer.Phone);
                }


                if(customer.ShippingAddress != null)
                {
                    customer.ShippingAddress.Address = htmlEncoder.Encode(customer.ShippingAddress.Address);
                    customer.ShippingAddress.City = htmlEncoder.Encode(customer.ShippingAddress.City);
                    customer.ShippingAddress.Country = htmlEncoder.Encode(customer.ShippingAddress.Country);
                    customer.ShippingAddress.Name = htmlEncoder.Encode(customer.ShippingAddress.Name);
                    customer.ShippingAddress.Postal = htmlEncoder.Encode(customer.ShippingAddress.Postal);
                }

                if(customer.BillingAddress != null)
                {
                    customer.BillingAddress.Postal = htmlEncoder.Encode(customer.BillingAddress.Postal);
                    customer.BillingAddress.Address = htmlEncoder.Encode(customer.BillingAddress.Address);
                    customer.BillingAddress.City = htmlEncoder.Encode(customer.BillingAddress.City);
                    customer.BillingAddress.Country = htmlEncoder.Encode(customer.BillingAddress.Country);
                    customer.BillingAddress.Name = htmlEncoder.Encode(customer.BillingAddress.Name);
                }
            }

            return customer;
        }

        public async Task<HttpResponseMessage> PostRequest(string url, object item)
        {

            HttpClient client = new HttpClient();

            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                // discover endpoints from metadata
                var ISclient = new HttpClient();
                var disco = await ISclient.GetDiscoveryDocumentAsync(_urls.Is);
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    return null;
                }

                // request token
                var tokenResponse = await ISclient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "NykantAPI"
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return null;
                }

                client.SetBearerToken(tokenResponse.AccessToken);
            }

            var itemJson = new StringContent(
                JsonConvert.SerializeObject(item),
                Encoding.UTF8,
                "application/json");

            string uri = _urls.Api + url;
            return await client.PostAsync(uri, itemJson);
        }

        public async Task<HttpResponseMessage> PatchRequest(string url, object item)
        {

            HttpClient client = new HttpClient();

            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                // discover endpoints from metadata
                var ISclient = new HttpClient();
                var disco = await ISclient.GetDiscoveryDocumentAsync(_urls.Is);
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    return null;
                }

                // request token
                var tokenResponse = await ISclient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "NykantAPI"
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return null;
                }

                client.SetBearerToken(tokenResponse.AccessToken);
            }

            var itemJson = new StringContent(
                JsonConvert.SerializeObject(item),
                Encoding.UTF8,
                "application/json");

            string uri = _urls.Api + url;

            return await client.PatchAsync(uri, itemJson);
        }

        public async Task<string> GetRequest(string url)
        {
            HttpClient client = new HttpClient();

            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                // discover endpoints from metadata
                var ISclient = new HttpClient();
                var disco = await ISclient.GetDiscoveryDocumentAsync(_urls.Is);
                if (disco.IsError)
                {
                    _logger.LogInformation($"is error: {disco.Error}");
                    return null;
                }

                // request token
                var tokenResponse = await ISclient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "NykantAPI"
                });

                if (tokenResponse.IsError)
                {
                    _logger.LogInformation($"is error: {tokenResponse.Error}");
                    return null;
                }

                client.SetBearerToken(tokenResponse.AccessToken);
            }

            string uri = null;
            if (url.StartsWith("/api"))
            {
                uri = "https://nykant.dk" + url;
            }
            else
            {
                uri = _urls.Api + url;
            }

            return await client.GetStringAsync(uri);
        }

        public async Task<HttpResponseMessage> DeleteRequest(string url)
        {
            HttpClient client = new HttpClient();

            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                // discover endpoints from metadata
                var ISclient = new HttpClient();
                var disco = await ISclient.GetDiscoveryDocumentAsync(_urls.Is);
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    return null;
                }

                // request token
                var tokenResponse = await ISclient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "NykantAPI"
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return null;
                }

                client.SetBearerToken(tokenResponse.AccessToken);
            }

            string uri = _urls.Api + url;
            return await client.DeleteAsync(uri);
        }

        public async Task<ParcelShopSearchResult> GetNearbyShops(GlsAddress glsAddress)
        {
            try
            {
                HttpClient client = new HttpClient();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ParcelShopSearchResult));

                var stream = await client.GetStreamAsync("http://www.gls.dk/webservices_v4/wsShopFinder.asmx/GetParcelShopDropPoint?"
                    + $"street={glsAddress.Street}&zipcode={glsAddress.ZipCode}&countryIso3166A2={glsAddress.CountryIso}&Amount={glsAddress.Amount}");

                ParcelShopSearchResult parcelSearch = (ParcelShopSearchResult)xmlSerializer.Deserialize(stream);

                return parcelSearch;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return null;
            }
        }
    }
}
