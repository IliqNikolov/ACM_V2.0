#pragma checksum "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f19f3fa3a5d6243d7e7e148a7ccf92131ae9d66e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meetings_list), @"mvc.1.0.view", @"/Views/Meetings/list.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Meetings/list.cshtml", typeof(AspNetCore.Views_Meetings_list))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f19f3fa3a5d6243d7e7e148a7ccf92131ae9d66e", @"/Views/Meetings/list.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87f576ad93479731ed601582d32dd41404c5cf03", @"/Views/_ViewImports.cshtml")]
    public class Views_Meetings_list : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.VoteDTO>>
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
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
  
    ViewData["Title"] = "list";

#line default
#line hidden
            BeginContext(78, 28, true);
            WriteLiteral("\r\n<h1>list</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(106, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f19f3fa3a5d6243d7e7e148a7ccf92131ae9d66e3766", async() => {
                BeginContext(129, 10, true);
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
            BeginContext(143, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(236, 40, false);
#line 16 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(276, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(332, 39, false);
#line 19 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.DisplayNameFor(model => model.Yes));

#line default
#line hidden
            EndContext();
            BeginContext(371, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(427, 38, false);
#line 22 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.DisplayNameFor(model => model.No));

#line default
#line hidden
            EndContext();
            BeginContext(465, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 28 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(583, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(632, 39, false);
#line 31 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(671, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(727, 38, false);
#line 34 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.DisplayFor(modelItem => item.Yes));

#line default
#line hidden
            EndContext();
            BeginContext(765, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(821, 37, false);
#line 37 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.DisplayFor(modelItem => item.No));

#line default
#line hidden
            EndContext();
            BeginContext(858, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(914, 65, false);
#line 40 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(979, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1000, 71, false);
#line 41 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1071, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1092, 69, false);
#line 42 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1161, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 45 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Meetings\list.cshtml"
}

#line default
#line hidden
            BeginContext(1200, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.VoteDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
