#pragma checksum "/Users/kleibert/Projects/projectChallenge/Views/Challenge/CreateUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecbc407b18e7891ddd379bf8ea13d6c2ff92f3da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Challenge_CreateUser), @"mvc.1.0.view", @"/Views/Challenge/CreateUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Challenge/CreateUser.cshtml", typeof(AspNetCore.Views_Challenge_CreateUser))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecbc407b18e7891ddd379bf8ea13d6c2ff92f3da", @"/Views/Challenge/CreateUser.cshtml")]
    public class Views_Challenge_CreateUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<projectChallenge.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(155, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(163, 12, false);
#line 8 "/Users/kleibert/Projects/projectChallenge/Views/Challenge/CreateUser.cshtml"
Write(Model.Userid);

#line default
#line hidden
            EndContext();
            BeginContext(175, 2, true);
            WriteLiteral(" \n");
            EndContext();
            BeginContext(178, 14, false);
#line 9 "/Users/kleibert/Projects/projectChallenge/Views/Challenge/CreateUser.cshtml"
Write(Model.Username);

#line default
#line hidden
            EndContext();
            BeginContext(192, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(194, 14, false);
#line 10 "/Users/kleibert/Projects/projectChallenge/Views/Challenge/CreateUser.cshtml"
Write(Model.Password);

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<projectChallenge.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591