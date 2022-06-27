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

                var client = new HttpClient();
                var disco = client.GetDiscoveryDocumentAsync(_urls.Is).Result;
                if (disco.IsError)
                {
                    _logger.LogError($"time: {DateTime.Now} - {disco.Error}");
                    //await Task.Delay(1000);
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
                    _logger.LogError($"time: {DateTime.Now} - {tokenResponse.Error}");
                    //await Task.Delay(1000);
                    goto tryAgain;
                }

                //set Token to the new token and set the expiry time to the new expiry time
                Token = tokenResponse;
                ExpiryTime = DateTime.UtcNow.AddSeconds(Token.ExpiresIn);

                //return fresh token
                return Token;
            }
        }
    }

    public interface ITokenService
    {
        TokenResponse GetToken();
    }
}
