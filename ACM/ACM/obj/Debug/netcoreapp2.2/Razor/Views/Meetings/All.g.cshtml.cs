#pragma checksum "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6255ee8e1321e6ed01c117caa7449d8adb454e91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meetings_All), @"mvc.1.0.view", @"/Views/Meetings/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Meetings/All.cshtml", typeof(AspNetCore.Views_Meetings_All))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6255ee8e1321e6ed01c117caa7449d8adb454e91", @"/Views/Meetings/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6485daa2af8ca738b86a3b90b4ac66419412f1a", @"/Views/_ViewImports.cshtml")]
    public class Views_Meetings_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ACM.Models.MeetingsListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
  
    ViewData["Title"] = "All";

#line default
#line hidden
            BeginContext(95, 16, true);
            WriteLiteral("\r\n<h1>All</h1>\r\n");
            EndContext();
#line 8 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
 if (User.IsInRole(MagicStrings.AdminString))
{

#line default
#line hidden
            BeginContext(161, 17, true);
            WriteLiteral("    <p>\r\n        ");
            EndContext();
            BeginContext(178, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6255ee8e1321e6ed01c117caa7449d8adb454e914049", async() => {
                BeginContext(201, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(215, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 13 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
}

#line default
#line hidden
            BeginContext(230, 104, true);
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(335, 40, false);
#line 18 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
               Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(375, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(443, 49, false);
#line 21 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
               Write(Html.DisplayNameFor(model => model.NumberOfVotes));

#line default
#line hidden
            EndContext();
            BeginContext(492, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(560, 40, false);
#line 24 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
               Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(600, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 30 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(763, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(836, 39, false);
#line 34 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(875, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(955, 48, false);
#line 37 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumberOfVotes));

#line default
#line hidden
            EndContext();
            BeginContext(1003, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1083, 39, false);
#line 40 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1122, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1202, 59, false);
#line 43 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1261, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 44 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                         if (User.IsInRole(MagicStrings.AdminString))
                        {

#line default
#line hidden
            BeginContext(1361, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1391, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
            BeginContext(1423, 53, false);
#line 47 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1478, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1508, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
            BeginContext(1540, 57, false);
#line 49 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
            EndContext();
#line 49 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
                                                                                      
                        }

#line default
#line hidden
            BeginContext(1626, 50, true);
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 53 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\All.cshtml"
            }

#line default
#line hidden
            BeginContext(1691, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ACM.Models.MeetingsListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591