namespace E_Store.Extensions
{
    using System.Collections.Generic;
    
    using Classes;

    using Newtonsoft.Json;
    
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
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

        public static IHtmlContent RenderFlashMessages(this IHtmlHelper helper)
        {
            //we can find an array with all the messages in the json format under the "Messages" key, we deserialize it using the extension method
            // Note: If we didn't store any messages, the method returns an empty List instance - which doesn't matter at all

            var messagesList = helper.ViewContext.TempData
                .DeserializeToObject<List<FlashMessage>>("Messages");

            var html = new HtmlContentBuilder();
            
            // Iterating through all the messages and generating HTML

            foreach (var msg in messagesList)
            {
                var container = new TagBuilder("div");
                
                container.AddCssClass($"alert alert-{ msg.Type.ToString().ToLower() }"); //adding bootstrap css
                container.InnerHtml.SetContent(msg.Message);

                html.AppendHtml(container);
            }

            return html;
        }
    }
}