#pragma checksum "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b3b63c01da273cfa739eca59cc5065928877cb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bills_View), @"mvc.1.0.view", @"/Views/Bills/View.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bills/View.cshtml", typeof(AspNetCore.Views_Bills_View))]
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
#line 1 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\_ViewImports.cshtml"
using ACM;

#line default
#line hidden
#line 2 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\_ViewImports.cshtml"
using ACM.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b3b63c01da273cfa739eca59cc5065928877cb3", @"/Views/Bills/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6485daa2af8ca738b86a3b90b4ac66419412f1a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bills_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ACM.Models.WallOfShameElementViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
            BeginContext(102, 103, true);
            WriteLiteral("\r\n<h1>View</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(206, 51, false);
#line 13 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.DisplayNameFor(model => model.ApartmentNumber));

#line default
#line hidden
            EndContext();
            BeginContext(257, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(313, 42, false);
#line 16 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(355, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(411, 55, false);
#line 19 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.DisplayNameFor(model => model.NumberOfUnpaidBills));

#line default
#line hidden
            EndContext();
            BeginContext(466, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 25 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(584, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(633, 50, false);
#line 28 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.DisplayFor(modelItem => item.ApartmentNumber));

#line default
#line hidden
            EndContext();
            BeginContext(683, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(739, 41, false);
#line 31 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(780, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(836, 54, false);
#line 34 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfUnpaidBills));

#line default
#line hidden
            EndContext();
            BeginContext(890, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(946, 65, false);
#line 37 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1011, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1032, 71, false);
#line 38 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1103, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1124, 69, false);
#line 39 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1193, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 42 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\View.cshtml"
}

#line default
#line hidden
            BeginContext(1232, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ACM.Models.WallOfShameElementViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
