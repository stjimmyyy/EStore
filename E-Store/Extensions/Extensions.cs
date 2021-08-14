namespace E_Store.Extensions
{
    using System;
    
    using Newtonsoft.Json;

    using Business.Managers;

    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class Extensions
    {
        // where T : new() indicates that the given type has to provide a non-parametric constructor
        public static T DeserializeToObject<T>(this ITempDataDictionary tempData, string key)
            where T : new()
        {
            // we search for anything stored under the given TempData key
            string entry = tempData[key]?.ToString();

            // if we find something under that key, we deserialize it from JSON to that type
            // if not, we return a new instance of that type (will be useful in the Controller extension)
            T result = entry == null
                ? new T()
                : JsonConvert.DeserializeObject<T>(entry);

            return result;
        }
        public static void SerializeObject<T>(this ITempDataDictionary tempData, T obj, string key)
        {
            tempData[key] = JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static IServiceCollection AddImageProcessing(this IServiceCollection services)
        {
            return ImageManager.ConfigureImageProcessingMiddleware(services);
        }

        public static IHtmlContent Script(this IHtmlHelper helper, Func<object, HelperResult> template)
        {
            helper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            return new StringHtmlContent(string.Empty);
        }

        public static IHtmlContent RenderScripts(this IHtmlHelper helper)
        {
            foreach (object key in helper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    if (helper.ViewContext.HttpContext.Items[key] is Func<object, HelperResult> template)
                    {
                        helper.ViewContext.Writer.Write(template(null));
                    }
                }
            }

            return new StringHtmlContent(string.Empty);
        }

        public static IHtmlContent PriceWithVat(this IHtmlHelper helper, decimal price, int vat, bool round = false)
        {
            var amount = (double) price * (1 + (vat / 100.0));

            amount = round
                ? Math.Round(amount)
                : Math.Round(amount, 2);

            return new HtmlContentBuilder().AppendHtml($"<span> ${amount} </span>");
        }

        public static IHtmlContent VatFromPrice(this IHtmlHelper helper, decimal price, int vat, bool round = false)
        {
            var amount = (double) price * (vat / 100.0);

            amount = round ? Math.Round(amount) : Math.Round(amount, 2);

            return new HtmlContentBuilder().AppendHtml($"<span> ${amount} </span>");
        }

        public static IHtmlContent Price(this IHtmlHelper helper, decimal price, bool vatPayer, int vat)
        {
            if (vatPayer)
            {
                price = (int) Math.Round(((double) price * (1 + (vat / 100.0))));
            }

            return new HtmlContentBuilder().AppendHtml($"<span> ${price} </span>");
        }
    }
}