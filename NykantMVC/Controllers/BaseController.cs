using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public const string BagSessionKey = "verysecretbagsessionkey";
        public const string CheckoutSessionKey = "verysecretseriouscheckoutsessionkey";
        public const string BagItemAmountKey = "verysecretseriousbagitemsessionkeyspecial";
        public const string ConsentCookieKey = "verysecretseriousconsentsessionkeyspecial";
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
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
                var disco = await ISclient.GetDiscoveryDocumentAsync("https://is");
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

            string uri = "https://api/api" + url;
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
                var disco = await ISclient.GetDiscoveryDocumentAsync("https://is");
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

            string uri = "https://api/api" + url;

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
                var disco = await ISclient.GetDiscoveryDocumentAsync("https://is");
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

            string uri = "https://api/api" + url;
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
                var disco = await ISclient.GetDiscoveryDocumentAsync("https://is");
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

            string uri = "https://api/api" + url;
            return await client.DeleteAsync(uri);
        }
    }
}
