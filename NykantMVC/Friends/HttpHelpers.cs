using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Friends
{
    public static class HttpHelpers
    {
        public static bool CookieExists(HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers.Values)
                foreach (var header in headers)
                    if (header.StartsWith($"{cookieName}="))
                    {
                        return true;
                    }
            return false;
        }

        public static bool CookieExists(HttpRequest request, string cookieName)
        {
            try
            {
                foreach (var headers in request.Headers.Values)
                    foreach (var header in headers)
                    {
                        if (header.Contains($"{cookieName}="))
                        {
                            return true;
                        }
                    }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
