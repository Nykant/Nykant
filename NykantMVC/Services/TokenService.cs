using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

namespace NykantMVC.Services
{
    public class TokenService : ITokenService
    {
        private readonly Urls _urls;
        private readonly IConfiguration conf;
        private readonly ILogger<TokenService> _logger;
        private TokenResponse Token { get; set; }
        private DateTime ExpiryTime { get; set; }
        private readonly object key = new object();
        
        public TokenService(IOptions<Urls> urls, ILogger<TokenService> logger, IConfiguration conf)
        {
            this.conf = conf;
            _logger = logger;
            _urls = urls.Value;
        }

        public TokenResponse GetToken()
        {
            //use token if it exists and is still fresh
            if (Token != null && ExpiryTime > DateTime.UtcNow)
            {
                return Token;
            }

            lock (key)
            {
                //use token if it exists and is still fresh
                if (Token != null && ExpiryTime > DateTime.UtcNow)
                {
                    return Token;
                }

                tryAgain:;

                try
                {
                    var client = new HttpClient();
                    var disco = client.GetDiscoveryDocumentAsync(_urls.Is).Result;
                    if (disco.IsError)
                    {
                        _logger.LogInformation($"time: {DateTime.Now} - {disco.Error}, {disco.Exception.Message}, {disco.Exception.StackTrace}, {disco.Exception.InnerException}, {disco.Exception.Data.Values}, {disco.Exception.TargetSite}, ---- Trying again...");
                        Thread.Sleep(1000);
                        goto tryAgain;
                    }

                    // request token
                    var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Address = disco.TokenEndpoint,

                        ClientId = "client",
                        ClientSecret = conf["ClientClientSecret"],
                        Scope = "NykantAPI"
                    }).Result;

                    if (tokenResponse.IsError)
                    {
                        _logger.LogInformation($"time: {DateTime.Now} - {disco.Error}, {disco.Exception.Message}, {disco.Exception.StackTrace}, {disco.Exception.InnerException}, {disco.Exception.Data.Values}, {disco.Exception.TargetSite}, ---- Trying again...");
                        Thread.Sleep(1000);
                        goto tryAgain;
                    }

                    //set Token to the new token and set the expiry time to the new expiry time
                    Token = tokenResponse;
                    ExpiryTime = DateTime.UtcNow.AddSeconds(Token.ExpiresIn);
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"time: {DateTime.Now} - {e.Message}, {e.StackTrace}, {e.InnerException}, {e.Data.Values}, {e.TargetSite}, ---- Trying again...");
                    Thread.Sleep(1000);
                    goto tryAgain;
                }


                //return fresh token
            }
            return Token;
        }
    }

    public interface ITokenService
    {
        TokenResponse GetToken();
    }
}
