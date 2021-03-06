#pragma checksum "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da9edc6cdaf75e42bb8ea032ef3a20b5cc8a1c77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Payment), @"mvc.1.0.view", @"/Views/Order/Payment.cshtml")]
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
#nullable restore
#line 9 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/_ViewImports.cshtml"
using E_Store.Models.Contact;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da9edc6cdaf75e42bb8ea032ef3a20b5cc8a1c77", @"/Views/Order/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ecc3acad7d53b0f0df8237042679c07db4bb0c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderPaymentViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 4 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
  
    ViewData["Title"] = "Delivery method";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>");
#nullable restore
#line 8 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n");
#nullable restore
#line 9 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
Write(Html.OrderState(2, User.Identity.IsAuthenticated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>Delivery method</h3>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "da9edc6cdaf75e42bb8ea032ef3a20b5cc8a1c775218", async() => {
                WriteLiteral("\n");
#nullable restore
#line 12 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
      
        bool isChecked = true;
        foreach (var item in Model.PaymentMethods)
        {
            string id = "deliveryProductId" + item.Value;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
       Write(Html.RadioButton("deliveryProductId", item.Value, isChecked, new { id = @id }));

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;\n            <label");
                BeginWriteAttribute("for", " for=\"", 466, "\"", 475, 1);
#nullable restore
#line 18 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
WriteAttributeValue("", 472, id, 472, 3, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 18 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
                         Write(item.Text);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label> <br />\n");
#nullable restore
#line 19 "/home/dimitar/RiderProjects/E-Store/E-Store/Views/Order/Payment.cshtml"
            isChecked = false;
        }
    

#line default
#line hidden
#nullable disable
                WriteLiteral("    <br />\n    <input type=\"submit\" value=\"Continue\" class=\"btn btn-primary\" />\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderPaymentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
