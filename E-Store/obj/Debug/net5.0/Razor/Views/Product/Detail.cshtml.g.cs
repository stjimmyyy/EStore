#pragma checksum "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdb164f6ac1982db63629620ccfdc75df6811255"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Detail), @"mvc.1.0.view", @"/Views/Product/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdb164f6ac1982db63629620ccfdc75df6811255", @"/Views/Product/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7feb16b69d71633aa9713f0953a224a087371c93", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<E_Store.Models.Product.ProductDetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ProductIndex.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-confirm", new global::Microsoft.AspNetCore.Html.HtmlString("Are you sure you want to delete this product?"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProcessStockForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Insert", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Review", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("review-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/reviewForm.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fdb164f6ac1982db63629620ccfdc75df68112558190", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 4 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
  
    ViewData["Title"] = "Product";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 7 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
<div class=""thumbnail"">

    <div class=""row carousel-holder"">

        <div class=""col-md-12"">
            <div id=""carousel-example-generic"" class=""carousel slide"" data-ride=""carousel"" data-interval=""false"">
                <ol class=""carousel-indicators"">
");
#nullable restore
#line 15 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                      
                        for (int i = 0; i < Model.Product.ImagesCount; i++)
                        {
                            string cls = (i == 0) ? "class='active'" : "";

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li data-target=\"#carousel-example-generic\" data-slide-to=\"");
#nullable restore
#line 19 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" ");
#nullable restore
#line 19 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                                                      Write(cls);

#line default
#line hidden
#nullable disable
            WriteLiteral("></li>\n");
#nullable restore
#line 20 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ol>\n                <div class=\"carousel-inner\">\n");
#nullable restore
#line 24 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                      
                        for (int i = 0; i < Model.Product.ImagesCount; i++)
                        {
                            string cls = (i == 0) ? "active" : "";
                            string path = "~/images/products/" + Model.Product.Id.ToString() + "_" + i.ToString() + ".jpeg";


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 1204, "\"", 1221, 2);
            WriteAttributeValue("", 1212, "item", 1212, 4, true);
#nullable restore
#line 30 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue(" ", 1216, cls, 1217, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                <img class=\"slide-image\"");
            BeginWriteAttribute("src", " src=\"", 1280, "\"", 1304, 1);
#nullable restore
#line 31 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 1286, Url.Content(path), 1286, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1305, "\"", 1331, 1);
#nullable restore
#line 31 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 1311, Model.Product.Title, 1311, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            </div>\n");
#nullable restore
#line 33 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                        }

                        if (Model.Product.ImagesCount == 0)
                        {
                            string path = "~/images/products/no_preview.png";

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"item active\">\n                                <img class=\"slide-image\"");
            BeginWriteAttribute("src", " src=\"", 1670, "\"", 1694, 1);
#nullable restore
#line 39 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 1676, Url.Content(path), 1676, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Previews are loading\">\n                            </div>\n");
#nullable restore
#line 41 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <a class=""left carousel-control"" href=""#carousel-example-generic"" data-slide=""prev"">
                    <span class=""glyphicon glyphicon-chevron-left""></span>
                </a>
                <a class=""right carousel-control"" href=""#carousel-example-generic"" data-slide=""next"">
                    <span class=""glyphicon glyphicon-chevron-right""></span>
                </a>
            </div>
        </div>

    </div>

    <div class=""caption-full"">
        <h4>
            <a href=""#"">");
#nullable restore
#line 57 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                   Write(Model.Product.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 58 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
              
                if (this.Context.User.IsInRole("Admin"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdb164f6ac1982db63629620ccfdc75df681125515204", async() => {
                WriteLiteral("<span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-url", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                                       WriteLiteral(Model.Product.Url);

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
            WriteLiteral("\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdb164f6ac1982db63629620ccfdc75df681125517648", async() => {
                WriteLiteral("<span class=\"glyphicon glyphicon-remove\" aria-hidden=\"true\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                                      WriteLiteral(Model.Product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 63 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </h4>\n\n        <h4 class=\"clearfix\">\n");
#nullable restore
#line 68 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
              
                if (Model.Product.DiscountPercent > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"label label-danger\">- ");
#nullable restore
#line 71 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                  Write(Model.Product.DiscountPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %  </span>\n                    <small><s> ");
#nullable restore
#line 72 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                          Write(Model.Product.OldPrice.Value.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </s></small>\n");
#nullable restore
#line 73 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"pull-right\">\n                ");
#nullable restore
#line 76 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
           Write(Model.Product.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </span>\n        </h4>\n        <h5>\n            roduct code: ");
#nullable restore
#line 80 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                    Write(Model.Product.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </h5>\n\n        ");
#nullable restore
#line 83 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
   Write(Html.Raw(Model.Product.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n    </div>\n\n    <div class=\"ratings\">\n        <h4>\n");
#nullable restore
#line 89 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
              
                if (Model.Product.Stock > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"pull-right label label-success large-icon\"> ");
#nullable restore
#line 92 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                                        Write(Model.Product.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral(" items in stock</span>\n");
#nullable restore
#line 93 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"pull-right pull-right label label-danger large-icon\">Sold out</span>\n");
#nullable restore
#line 97 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </h4>\n        <p>\n            <rating");
            BeginWriteAttribute("value", " value=\"", 3974, "\"", 4003, 1);
#nullable restore
#line 101 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 3982, Model.Product.Rating, 3982, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></rating>\n            ");
#nullable restore
#line 102 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
       Write(Model.Product.Reviews.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp; reviews\n        </p>\n    </div>\n\n\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdb164f6ac1982db63629620ccfdc75df681125524295", async() => {
                WriteLiteral("\n        <div class=\"form-group\">\n            <input type=\"hidden\" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 4249, "\"", 4274, 1);
#nullable restore
#line 109 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 4257, Model.Product.Id, 4257, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
            <input type=""text"" class=""form-control input-quantity"" name=""quantity"" value=""1"" /> items
            <button type=""submit"" name=""add_to_cart"" class=""btn btn-primary"" style=""margin-left:20px;""><span class=""glyphicon glyphicon-shopping-cart"" aria-hidden=""true""></span> Add to cart</button>
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute(",", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
#nullable restore
#line 115 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
      
        if (this.Context.User.IsInRole("Admin"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdb164f6ac1982db63629620ccfdc75df681125527463", async() => {
                WriteLiteral("\n                <div class=\"form-group\">\n                    <input type=\"hidden\" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 4860, "\"", 4885, 1);
#nullable restore
#line 120 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 4868, Model.Product.Id, 4868, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                    <input type=""text"" class=""form-control input-quantity"" name=""quantity"" value=""1"" /> pcs
                    <button type=""submit"" name=""add_to_stock"" class=""btn btn-default"" style=""margin-left:20px;""><span class=""glyphicon glyphicon-log-in"" aria-hidden=""true""></span> Add to stock</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 125 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n");
#nullable restore
#line 128 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
      
        
        if (this.Context.User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"text-right\">\n                <a class=\"btn btn-success\" id=\"write-review\">Write a review</a>\n            </div>\n");
#nullable restore
#line 135 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdb164f6ac1982db63629620ccfdc75df681125530920", async() => {
                WriteLiteral("\n        <input name=\"rating\" id=\"rating\"");
                BeginWriteAttribute("value", " value=\"", 5674, "\"", 5682, 0);
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\" />\n        <input name=\"ProductId\" id=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 5747, "\"", 5772, 1);
#nullable restore
#line 140 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 5755, Model.Product.Id, 5755, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\" />\n        <p class=\"text-center\">\n");
#nullable restore
#line 142 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
              
                for (int i = 0; i < 5; i++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <span class=\"glyphicon glyphicon-star-empty large-icon review-star\"></span>\n");
#nullable restore
#line 146 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </p>
        <div class=""form-group"">
            <label for=""Content"">How satisfied are you with the product?</label>
            <textarea class=""form-control"" name=""Content"" id=""content"" required=""required"" rows=""5""></textarea>
            <div class=""clear""></div>
        </div>
        <div class=""text-center"">
            <input class=""btn btn-info"" name=""send"" id=""send"" value=""Send"" type=""submit"" />
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 138 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                                                WriteLiteral(Model.Product.Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["productUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["productUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    \n");
#nullable restore
#line 159 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
     foreach (var review in Model.Product.Reviews)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\n            <div class=\"col-md-12\">\n                <rating");
            BeginWriteAttribute("value", " value=\"", 6620, "\"", 6642, 1);
#nullable restore
#line 163 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
WriteAttributeValue("", 6628, review.Rating, 6628, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></rating>\n                ");
#nullable restore
#line 164 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
           Write(review.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <span class=\"pull-right\">");
#nullable restore
#line 165 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
                                    Write(review.Sent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                <p>");
#nullable restore
#line 166 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
              Write(review.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            </div>\n        </div>\n");
#nullable restore
#line 169 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Product/Detail.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdb164f6ac1982db63629620ccfdc75df681125537350", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<E_Store.Models.Product.ProductDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591