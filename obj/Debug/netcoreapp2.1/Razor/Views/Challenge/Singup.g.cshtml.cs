#pragma checksum "/Users/kleibert/Projects/projectChallenge/Views/Challenge/Singup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fa5b4120864a970d71479d7ed9cc3b223e27449"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Challenge_Singup), @"mvc.1.0.view", @"/Views/Challenge/Singup.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Challenge/Singup.cshtml", typeof(AspNetCore.Views_Challenge_Singup))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fa5b4120864a970d71479d7ed9cc3b223e27449", @"/Views/Challenge/Singup.cshtml")]
    public class Views_Challenge_Singup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<projectChallenge.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(158, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(169, 957, true);
            WriteLiteral(@"
<div class=""row h-100 justify-content-center align-items-center"">
    <div class=""col-6  border border-secondary"">
        <form action=""CreateUser"" method=""POST"" runat=""server"" onsubmit=""return validate();"">
            <fieldset>
                <div>
                    <label for=""PessoaId"">Username</label>
                </div>
                <div>
                    <input type=""text"" name=""username"" id=""username"" placeholder=""username"" />
                </div>
                <div id=""userResult""></div>
                <div>
                    <label for=""Nome"">Password</label>
                </div>
                <div>
                    <input type=""text"" name=""password"" id=""password"" placeholder=""password"" />
                </div>
                <div id=""passResult""></div>
                <br />
                <p><input type=""submit"" class=""btn btn-info"" value=""Sing UP"" /></p>




                ");
            EndContext();
            BeginContext(1128, 66, false);
#line 33 "/Users/kleibert/Projects/projectChallenge/Views/Challenge/Singup.cshtml"
            Write(Model.Username == null ? "" : Model.Username + " User name existe");

#line default
#line hidden
            EndContext();
            BeginContext(1195, 42, true);
            WriteLiteral("\r\n                <br />\r\n                ");
            EndContext();
            BeginContext(1239, 110, false);
#line 35 "/Users/kleibert/Projects/projectChallenge/Views/Challenge/Singup.cshtml"
            Write(Model.Password == null ? "" : Model.Password + " you can not use this password, please enter a valid password");

#line default
#line hidden
            EndContext();
            BeginContext(1350, 68, true);
            WriteLiteral("\r\n\r\n            </fieldset>\r\n        </form>\r\n    </div>\r\n\r\n</div>\r\n");
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
