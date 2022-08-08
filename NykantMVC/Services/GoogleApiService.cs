using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace NykantMVC.Services
{
    public class GoogleApiService : IGoogleApiService
    {
        private string AccessToken { get; set; }
        private string RefreshToken { get; set; }
        public void SetTokens(string accessToken, string refreshToken = null)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string GetAccessToken()
        {
            return AccessToken;
        }

        public string GetRefreshToken()
        {
            return RefreshToken;
        }
    }

    public interface IGoogleApiService
    {
        void SetTokens(string accessToken, string refreshToken = null);
        string GetRefreshToken();
        string GetAccessToken();
    }
}
