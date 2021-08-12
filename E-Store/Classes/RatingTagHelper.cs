namespace E_Store.Classes
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public class RatingTagHelper : TagHelper
    {
        private int value = 0;

        public string Value
        {
            get => value.ToString();
            set => this.value = int.Parse(value);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";

            for (int i = 0; i < value; i++)
            {
                var builder = new TagBuilder("span");
                builder.AddCssClass("glyphicon glyphicon-star");
                output.Content.AppendHtml(builder);
            }

            for (int i = 0; i < 5 - value; i++)
            {
                var builder = new TagBuilder("span");
                builder.AddCssClass("glyphicon glyphicon-star-empty");
                output.Content.AppendHtml(builder);
            }
        }
    }
}