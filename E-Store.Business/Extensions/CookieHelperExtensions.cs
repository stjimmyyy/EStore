namespace E_Store.Business.Extensions
{
    using System;
    using Microsoft.AspNetCore.Http;
    
    public static class CookieHelperExtensions
    {
        public static void SetCookie(this HttpContext context, string key, string value, TimeSpan expires)
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.Add(expires),
                HttpOnly = true
            };

            if (context.Request.Cookies[key] == null)
            {
                var cookieOld = context.Request.Cookies[key];
                context.Response.Cookies.Append(key, cookieOld ?? throw new InvalidOperationException(), cookieOptions);
            }
            else
            {
                cookieOptions.Expires = DateTime.Now.Add(expires);
                context.Response.Cookies.Append(key, value, cookieOptions);
            }
            
        }
        
        public static string GetCookie(this HttpContext context, string key)
            => context.Request.Cookies[key] ?? string.Empty;
    }
}