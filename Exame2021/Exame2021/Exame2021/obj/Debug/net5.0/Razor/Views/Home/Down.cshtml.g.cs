#pragma checksum "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "052426da2b59794acb6ccd94d47b49e0db081849"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Down), @"mvc.1.0.view", @"/Views/Home/Down.cshtml")]
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
#nullable restore
#line 1 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\_ViewImports.cshtml"
using Exame2021;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\_ViewImports.cshtml"
using Exame2021.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"052426da2b59794acb6ccd94d47b49e0db081849", @"/Views/Home/Down.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bee196333c5b28a303f0d2d2a5f97147e55bdbf6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Down : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Exame2021.Models.Download>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <table id=\"Table\" class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 8 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml"
               Write(Html.DisplayNameFor(model => model.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 11 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml"
               Write(Html.DisplayNameFor(model => model.Documento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n\r\n");
#nullable restore
#line 18 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 22 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 25 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Documento.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 28 "C:\Users\rppin\Downloads\Exame2021\Exame2021\Exame2021\Views\Home\Down.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n            \r\n    </table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Exame2021.Models.Download>> Html { get; private set; }
    }
}
#pragma warning restore 1591
