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
        private readonly ILogger<BaseController> _logger;
        private readonly Urls _urls;

        public BaseController(ILogger<BaseController> logger, IOptions<Urls> urls)
        {
            _logger = logger;
            _urls = urls.Value;
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
                Console.WriteLine("url starts with /api");
                uri = "https://nykant.dk" + url;
            }
            else
            {
                Console.WriteLine("url doesnt start with /api");
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
