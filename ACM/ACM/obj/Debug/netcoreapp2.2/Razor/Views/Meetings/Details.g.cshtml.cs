#pragma checksum "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd1ae4787790b2715900f03e581112f282aacc16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meetings_Details), @"mvc.1.0.view", @"/Views/Meetings/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Meetings/Details.cshtml", typeof(AspNetCore.Views_Meetings_Details))]
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
using Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd1ae4787790b2715900f03e581112f282aacc16", @"/Views/Meetings/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87f576ad93479731ed601582d32dd41404c5cf03", @"/Views/_ViewImports.cshtml")]
    public class Views_Meetings_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.MeetingDetailsDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(78, 108, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(187, 32, false);
#line 13 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
       Write(Html.DisplayName("Meeting Text"));

#line default
#line hidden
            EndContext();
            BeginContext(219, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(283, 36, false);
#line 16 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(319, 120, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(440, 29, false);
#line 24 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
           Write(Html.DisplayName("Vote Text"));

#line default
#line hidden
            EndContext();
            BeginContext(469, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(525, 30, false);
#line 27 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
           Write(Html.DisplayName("Votes: Yes"));

#line default
#line hidden
            EndContext();
            BeginContext(555, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(611, 29, false);
#line 30 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
           Write(Html.DisplayName("Votes: No"));

#line default
#line hidden
            EndContext();
            BeginContext(640, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 35 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
         foreach (var item in Model.Votes)
        {

#line default
#line hidden
            BeginContext(758, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(819, 39, false);
#line 39 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(858, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(926, 38, false);
#line 42 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.Yes));

#line default
#line hidden
            EndContext();
            BeginContext(964, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1032, 37, false);
#line 45 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.No));

#line default
#line hidden
            EndContext();
            BeginContext(1069, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 48 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1124, 31, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n");
            EndContext();
#line 52 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
     if (User.IsInRole(MagicStrings.AdminString))
    {
        

#line default
#line hidden
            BeginContext(1222, 54, false);
#line 54 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1278, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(1288, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
            BeginContext(1300, 58, false);
#line 56 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
   Write(Html.ActionLink("Delete", "Delete", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1360, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(1370, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
#line 58 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(1380, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1384, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd1ae4787790b2715900f03e581112f282aacc169245", async() => {
                BeginContext(1404, 16, true);
                WriteLiteral("Back to Meetings");
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
            BeginContext(1424, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.MeetingDetailsDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
