#pragma checksum "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "123b06bf6659e475f1ffbb8d3dc08ecae512e6bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Checkout), @"mvc.1.0.view", @"/Views/Cart/Checkout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Checkout.cshtml", typeof(AspNetCore.Views_Cart_Checkout))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 3 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\_ViewImports.cshtml"
using P310_ASP_Start.Models;

#line default
#line hidden
#line 2 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\_ViewImports.cshtml"
using P310_ASP_Start.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"123b06bf6659e475f1ffbb8d3dc08ecae512e6bc", @"/Views/Cart/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95dfdbc5663544d18375ff6aefbc4e9722721092", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CardItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
            BeginContext(69, 115, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n            <h2>Checkout</h2>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
             if (Model.Count == 0)
            {

#line default
#line hidden
            BeginContext(235, 255, true);
            WriteLiteral("                <div class=\"alert alert-warning\">\r\n                    Deer user, you have not added anything to your God damn cart. Go and get something.\r\n                    <br />\r\n                    <a href=\"/\">Go there!</a>\r\n                </div>\r\n");
            EndContext();
#line 20 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(538, 453, true);
            WriteLiteral(@"                <table class=""table table-bordered table-striped table-hovered"">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Name</th>
                            <th>Category</th>
                            <th>Price</th>
                            <th>Count</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 34 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
                         foreach (var pro in Model)
                        {

#line default
#line hidden
            BeginContext(1071, 108, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1179, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "581ce8078a4540189e1c58fcba62d267", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1189, "~/img/", 1189, 6, true);
#line 38 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
AddHtmlAttributeValue("", 1195, pro.Image, 1195, 10, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1221, 77, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(1299, 15, false);
#line 40 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
                               Write(pro.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1314, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1358, 16, false);
#line 41 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
                               Write(pro.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(1374, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1418, 16, false);
#line 42 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
                               Write(pro.ProductPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1434, 47, true);
            WriteLiteral(" AZN</td>\r\n                                <td>");
            EndContext();
            BeginContext(1482, 9, false);
#line 43 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
                               Write(pro.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1491, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 45 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
                        }

#line default
#line hidden
            BeginContext(1560, 56, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
            EndContext();
#line 48 "C:\Users\Code\source\repos\P310_ASP_Start\P310_ASP_Start\Views\Cart\Checkout.cshtml"
            }

#line default
#line hidden
            BeginContext(1631, 36, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CardItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
