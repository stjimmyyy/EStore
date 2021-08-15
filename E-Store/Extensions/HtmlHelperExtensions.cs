namespace E_Store.Extensions
{
    using System.Linq;
    using System.Collections.Generic;

    using E_Store.Data.Models;
    using Classes;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    
    public static class HtmlHelperExtensions
    {
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
        public static IHtmlContent RenderCategories(this IHtmlHelper helper,
            IEnumerable<Category> categories,
            string parentUrl = "")
        {
            var ulTag = new TagBuilder("ul");
            
            ulTag.AddCssClass("nav nav-list tree");

            foreach (var category in categories)
            {
                var url = parentUrl + "/" + category.Url;

                var liTag = new TagBuilder("li");

                if (category.ChildCategories.Count > 0)
                {
                    var labelTag = new TagBuilder("label");
                    
                    labelTag.AddCssClass("tree-toggler nav header");
                    labelTag.Attributes.Add("data-path", url);
                    labelTag.InnerHtml.SetContent(category.Title);

                    liTag.InnerHtml.SetHtmlContent(labelTag);
                    liTag.InnerHtml.AppendHtml(RenderCategories(helper,
                        category.ChildCategories.OrderBy(c => c.OrderNo), url));
                }
                else
                {
                    var anchorTag = new TagBuilder("a");
                    
                    anchorTag.Attributes.Add("href", "/Product/Index?id=" + category.Id);
                    anchorTag.Attributes.Add("data-path", url);
                    anchorTag.InnerHtml.SetContent(category.Title);

                    liTag.InnerHtml.SetHtmlContent(anchorTag);
                }

                ulTag.InnerHtml.AppendHtml(liTag);
            }

            return new HtmlContentBuilder().AppendHtml(ulTag);
        }

        public static IHtmlContent Address(this IHtmlHelper helper, Address address)
        {
            var firstLine = address.Street + " " + address.RegistryNumber;

            if (address.OrientationNumber.HasValue)
                firstLine += " / " + address.OrientationNumber.Value;

            return new HtmlContentBuilder()
                .AppendHtml($@"<div>
                                {firstLine}<br />
                                {address.City}<br />
                                {address.Zip}
                            </div>");
        }

        public static IHtmlContent CustomerName(this IHtmlHelper helper, PersonDetail personDetail)
        {
            string result;

            if (!string.IsNullOrEmpty(personDetail.CompanyName))
                result = $"<span>{personDetail.CompanyName}</span>";
            else if (string.IsNullOrEmpty(personDetail.FullName))
                result = "<span>End customer </span>";
            else
                result = $"<span>{personDetail.FullName}</span>";

            return new HtmlContentBuilder().AppendHtml(result);
        }
    }
}