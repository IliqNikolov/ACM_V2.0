#pragma checksum "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Home\JokeError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a876365e3b2da9495d4634bf2f47bda1fd262c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_JokeError), @"mvc.1.0.view", @"/Views/Home/JokeError.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/JokeError.cshtml", typeof(AspNetCore.Views_Home_JokeError))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a876365e3b2da9495d4634bf2f47bda1fd262c", @"/Views/Home/JokeError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87f576ad93479731ed601582d32dd41404c5cf03", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_JokeError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ErrorDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Home\JokeError.cshtml"
  
    ViewData["Title"] = "JokeError";

#line default
#line hidden
            BeginContext(70, 286, true);
            WriteLiteral(@"
    <h1>There was an error while processing your 100% not malicious request. We have dispachen a crew of underpaid slave snails to fix the issue.If u receive Mail, Email, Phone call, Fax or Telepathic message from our snails plase give them this code:</h1>
    <div class=""col-md-4"">");
            EndContext();
            BeginContext(357, 15, false);
#line 7 "C:\Users\crazy\Desktop\ACM_v2.0\ACM_V2.0\ACM\ACM\Views\Home\JokeError.cshtml"
                     Write(Model.ErrorCode);

#line default
#line hidden
            EndContext();
            BeginContext(372, 10, true);
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ErrorDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
