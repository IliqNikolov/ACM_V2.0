#pragma checksum "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c56eef29e19cf5f1039353101344e4c253abc429"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bills_All), @"mvc.1.0.view", @"/Views/Bills/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bills/All.cshtml", typeof(AspNetCore.Views_Bills_All))]
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
#line 2 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c56eef29e19cf5f1039353101344e4c253abc429", @"/Views/Bills/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87f576ad93479731ed601582d32dd41404c5cf03", @"/Views/_ViewImports.cshtml")]
    public class Views_Bills_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.BillsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Filters.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 5 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
  
    ViewData["Title"] = "All";

#line default
#line hidden
            BeginContext(218, 18, true);
            WriteLiteral("\r\n<h1>All</h1>\r\n\r\n");
            EndContext();
            BeginContext(236, 255, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c56eef29e19cf5f1039353101344e4c253abc4294655", async() => {
                BeginContext(242, 242, true);
                WriteLiteral("\r\n    <label class=\"radio-inline\">\r\n        <input type=\"radio\" name=\"Owner\" checked=\"\" id=\"AllOwners\"> All Bills\r\n    </label>\r\n    <label class=\"radio-inline\">\r\n        <input type=\"radio\" name=\"Owner\" id=\"MyBills\"> My Bills\r\n    </label>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(491, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(493, 349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c56eef29e19cf5f1039353101344e4c253abc4296373", async() => {
                BeginContext(499, 336, true);
                WriteLiteral(@"
    <label class=""radio-inline"">
        <input type=""radio"" name=""Paid"" checked="""" id=""All""> All Bills
    </label>
    <label class=""radio-inline"">
        <input type=""radio"" name=""Paid"" id=""Paid""> Paid
    </label>
    <label class=""radio-inline"">
        <input type=""radio"" name=""Paid"" id=""Unpaid""> Unpaid
    </label>
");
                EndContext();
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
            EndContext();
            BeginContext(842, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
 if (User.IsInRole(MagicStrings.AdminString))
{

#line default
#line hidden
            BeginContext(894, 17, true);
            WriteLiteral("    <p>\r\n        ");
            EndContext();
            BeginContext(911, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c56eef29e19cf5f1039353101344e4c253abc4298463", async() => {
                BeginContext(934, 10, true);
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
            BeginContext(948, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 35 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
}

#line default
#line hidden
            BeginContext(963, 86, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1050, 45, false);
#line 41 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
           Write(Html.DisplayNameFor(model => model.Apartment));

#line default
#line hidden
            EndContext();
            BeginContext(1095, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1151, 42, false);
#line 44 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(1193, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1249, 40, false);
#line 47 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1289, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1345, 40, false);
#line 50 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
           Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(1385, 21, true);
            WriteLiteral("\r\n            </th>\r\n");
            EndContext();
#line 52 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
             if (User.IsInRole(MagicStrings.AdminString))
            {

#line default
#line hidden
            BeginContext(1480, 27, true);
            WriteLiteral("                <th></th>\r\n");
            EndContext();
#line 55 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
            }

#line default
#line hidden
            BeginContext(1522, 65, true);
            WriteLiteral("            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 60 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1636, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1651, "\"", 1803, 4);
            WriteAttributeValue("", 1659, "background-color:", 1659, 17, true);
            WriteAttributeValue("", 1676, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 62 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                                         if (item.Ispayed)
        {

#line default
#line hidden
                BeginContext(1707, 12, true);
                WriteLiteral("            ");
                EndContext();
                BeginContext(1721, 12, true);
                WriteLiteral("lightgreen\r\n");
                EndContext();
#line 65 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(1769, 12, true);
                WriteLiteral("            ");
                EndContext();
                BeginContext(1783, 9, true);
                WriteLiteral("#ff9999\r\n");
                EndContext();
#line 69 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
        }

#line default
#line hidden
                PopWriter();
            }
            ), 1676, 125, false);
            WriteAttributeValue("", 1801, ";", 1801, 1, true);
            WriteAttributeValue(" ", 1802, "", 1803, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1804, "\"", 2264, 2);
            WriteAttributeValue(" ", 1812, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 69 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                      if (ViewBag.UserApartment == item.Apartment)
        {

            if (item.Ispayed)
            {

#line default
#line hidden
                BeginContext(1919, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(1937, 13, true);
                WriteLiteral("MyBill Paid\r\n");
                EndContext();
#line 75 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
            }
            else
            {

#line default
#line hidden
                BeginContext(1998, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(2016, 16, true);
                WriteLiteral("MyBill NotPaid\r\n");
                EndContext();
#line 79 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
            }
        }
        else {
            if (item.Ispayed)
            {

#line default
#line hidden
                BeginContext(2120, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(2138, 16, true);
                WriteLiteral("NotMyBill Paid\r\n");
                EndContext();
#line 85 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
            }
            else
            {

#line default
#line hidden
                BeginContext(2202, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(2220, 19, true);
                WriteLiteral("NotMyBill NotPaid\r\n");
                EndContext();
#line 89 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
            }
        }

#line default
#line hidden
                PopWriter();
            }
            ), 1813, 450, false);
            WriteAttributeValue(" ", 2263, "", 2264, 1, true);
            EndWriteAttribute();
            BeginContext(2265, 45, true);
            WriteLiteral(">\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2311, 44, false);
#line 92 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
               Write(Html.DisplayFor(modelItem => item.Apartment));

#line default
#line hidden
            EndContext();
            BeginContext(2355, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2423, 41, false);
#line 95 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(2464, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2532, 39, false);
#line 98 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(2571, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2639, 39, false);
#line 101 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
               Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(2678, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 103 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                 if (User.IsInRole(MagicStrings.AdminString))
                {

#line default
#line hidden
            BeginContext(2785, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(2836, 53, false);
#line 106 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2889, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(2918, 57, false);
#line 107 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2975, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
#line 109 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                }

#line default
#line hidden
            BeginContext(3023, 22, true);
            WriteLiteral("                <td>\r\n");
            EndContext();
#line 111 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                     if (ViewBag.UserApartment == item.Apartment && !item.Ispayed)
                    {

                        

#line default
#line hidden
            BeginContext(3179, 51, false);
#line 114 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                   Write(Html.ActionLink("Pay", "Pay", new { id = item.Id }));

#line default
#line hidden
            EndContext();
#line 114 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
                                                                            

                    }

#line default
#line hidden
            BeginContext(3257, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 119 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
        }

#line default
#line hidden
            BeginContext(3310, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(3334, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c56eef29e19cf5f1039353101344e4c253abc42921006", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 122 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Bills\All.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3399, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Data.ACMUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<Data.ACMUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.BillsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
