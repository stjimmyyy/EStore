#pragma checksum "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b57a8614a540134e1cef0bfcaa3896d79e981d9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product__ProductThumbnailAdminPartialView), @"mvc.1.0.view", @"/Views/Product/_ProductThumbnailAdminPartialView.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Classes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models.Person;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models.Setting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b57a8614a540134e1cef0bfcaa3896d79e981d9e", @"/Views/Product/_ProductThumbnailAdminPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6a5a0e5dd26344f2d222d66840d6a8f62fceb20", @"/Views/_ViewImports.cshtml")]
    public class Views_Product__ProductThumbnailAdminPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-confirm", new global::Microsoft.AspNetCore.Html.HtmlString("Are you sure you want to delete this product?"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProcessStockForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"thumbnail\">\n\n    <div class=\"product-image text-center\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b57a8614a540134e1cef0bfcaa3896d79e981d9e6868", async() => {
                WriteLiteral("\n");
#nullable restore
#line 5 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
               string imagePath = Model.ImagesCount > 0 ? "~/images/products/" + Model.ProductId + "_thumb.png" : "~/images/products/no_preview.png";

#line default
#line hidden
#nullable disable
                WriteLiteral("            <img");
                BeginWriteAttribute("alt", " alt=\"", 284, "\"", 290, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"product-image-background\"");
                BeginWriteAttribute("src", " src=", 324, "", 352, 1);
#nullable restore
#line 6 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
WriteAttributeValue("", 329, Url.Content(imagePath), 329, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 86, "~/images/products/", 86, 18, true);
#nullable restore
#line 4 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
AddHtmlAttributeValue("", 104, Model.Url, 104, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n\n    <div class=\"product-caption\">\n        <h4>\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b57a8614a540134e1cef0bfcaa3896d79e981d9e9409", async() => {
#nullable restore
#line 12 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                                       Write(Model.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 447, "~/Products/", 447, 11, true);
#nullable restore
#line 12 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
AddHtmlAttributeValue("", 458, Model.Url, 458, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b57a8614a540134e1cef0bfcaa3896d79e981d9e11130", async() => {
                WriteLiteral("<span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-url", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                                                               WriteLiteral(Model.Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["url"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-url", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["url"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b57a8614a540134e1cef0bfcaa3896d79e981d9e13577", async() => {
                WriteLiteral("<span class=\"glyphicon glyphicon-remove\" aria-hidden=\"true\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                                                              WriteLiteral(Model.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </h4>\n    </div>\n    <p class=\"product-description\">");
#nullable restore
#line 17 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                              Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <div class=\"product-price\">\n        <h4 class=\"text-right\">\n");
#nullable restore
#line 20 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
              
                if (Model.DiscountPercent > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"pull-left\">\n                        <span class=\"label label-danger\">- ");
#nullable restore
#line 24 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                                                      Write(Model.DiscountPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %  </span>\n                        <small><s>");
#nullable restore
#line 25 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                             Write(Model.OldPrice.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD</s></small>\n                    </span>\n");
#nullable restore
#line 27 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 29 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
       Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD\n        </h4>\n    </div>\n    <div class=\"clear\"></div>\n    <div class=\"ratings\">\n");
#nullable restore
#line 34 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
          
            if (Model.Stock > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"pull-right label label-success\">\n                    ");
#nullable restore
#line 38 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
               Write(Model.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral(" items in stock\n                </span>\n");
#nullable restore
#line 40 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <rating");
            BeginWriteAttribute("value", " value=\"", 1714, "\"", 1735, 1);
#nullable restore
#line 42 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
WriteAttributeValue("", 1722, Model.Rating, 1722, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></rating>\n    </div>\n    <div>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b57a8614a540134e1cef0bfcaa3896d79e981d9e19398", async() => {
                WriteLiteral("\n            <div class=\"form-group\">\n                <input type=\"hidden\" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 1931, "\"", 1955, 1);
#nullable restore
#line 47 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
WriteAttributeValue("", 1939, Model.ProductId, 1939, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                <input type=""text"" class=""form-control input-quantity"" name=""quantity"" value=""1"" style=""float:left"" /> pcs
                <button type=""submit"" name=""add_to_cart"" class=""btn btn-primary"" style=""margin-left: 20px;""><span class=""glyphicon glyphicon-shopping-cart"" aria-hidden=""true""></span> Add to cart</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n    <div>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b57a8614a540134e1cef0bfcaa3896d79e981d9e22107", async() => {
                WriteLiteral("\n            <div class=\"form-group\">\n                <input type=\"hidden\" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 2517, "\"", 2541, 1);
#nullable restore
#line 56 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/_ProductThumbnailAdminPartialView.cshtml"
WriteAttributeValue("", 2525, Model.ProductId, 2525, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                <input type=""text"" class=""form-control input-quantity"" name=""quantity"" value=""1"" style=""float:left"" /> pcs
                <button type=""submit"" name=""add_to_stock"" class=""btn btn-default"" style=""margin-left: 20px;""><span class=""glyphicon glyphicon-log-in"" aria-hidden=""true""></span> Add to stock</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
