#pragma checksum "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4974778fcc97e940f5d6771cad5978ad9d42574"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Details.cshtml", typeof(AspNetCore.Views_Users_Details))]
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
#line 1 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4974778fcc97e940f5d6771cad5978ad9d42574", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DTO.UserWebDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(80, 117, true);
            WriteLiteral("\r\n<h1>User Details</h1>\r\n\r\n<div>\r\n    \r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(198, 38, false);
#line 14 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(236, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(298, 34, false);
#line 17 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(332, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(393, 45, false);
#line 20 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(438, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(500, 41, false);
#line 23 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(541, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(602, 44, false);
#line 26 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(646, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(708, 40, false);
#line 29 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(748, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(809, 44, false);
#line 32 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(853, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(915, 40, false);
#line 35 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(955, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1016, 44, false);
#line 38 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(1060, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1122, 40, false);
#line 41 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(1162, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1210, 54, false);
#line 46 "C:\Users\Kale\Desktop\ICT Treca godina\ASP.Net\MojProjekat2019\ASPOnlineShop\WebApp\Views\Users\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1264, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1272, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4974778fcc97e940f5d6771cad5978ad9d425748917", async() => {
                BeginContext(1294, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1310, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DTO.UserWebDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
