using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace NykantMVC.Extensions
{
    public class CheckoutCookie
    {
        public static void AppendCheckout<T>(T value, HttpResponse response, int minutes)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.Now.AddMinutes(minutes),
                Domain = "https://localhost:5002",
                IsEssential = true
            };

            response.Cookies.Append("minlivreterfaktiskspeghettimedkødsovsmedparmesan", JsonConvert.SerializeObject(value), cookieOptions);
        }

        public static T GetCheckout<T>(HttpRequest request)
        {
            return JsonConvert.DeserializeObject<T>(request.Cookies["minlivreterfaktiskspeghettimedkødsovsmedparmesan"]);
        }
    }
}
