#pragma checksum "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "134ec68d6c6cf7c35c17ade2c6b26f3120ae5c03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\_ViewImports.cshtml"
using CasaDeShow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\_ViewImports.cshtml"
using CasaDeShow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"134ec68d6c6cf7c35c17ade2c6b26f3120ae5c03", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e14b4a6b6de72f110567a0b7dc451115319be6d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CasaDeShow.Models.Evento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1 class=\"fonte-clara\">Eventos</h2>\n\n");
            WriteLiteral("\n<table class=\"table table-bordered table-hover\">\n    <thead>\n        <tr class=\"table-dark text-center\">\n            <th>\n");
            WriteLiteral("               Evento\n            </th>\n            <th>\n");
            WriteLiteral("                Capacidade\n            </th>\n            <th>\n");
            WriteLiteral("                Data\n            </th>\n            <th>\n");
            WriteLiteral("                Valor do ingresso\n            </th>\n            <th>\n");
            WriteLiteral("                Local\n            </th>\n            <th>\n");
            WriteLiteral("                Gênero musical\n            </th>\n            <th>\n\n            </th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 39 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
         foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"table-primary text-center\">\n            <td>\n                ");
#nullable restore
#line 42 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NomeEvento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 45 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Capacidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 48 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 51 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ValorIngresso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 54 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Casadeshow.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 57 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.GeneroMusica));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                <button type=\"submit\" class=\"btn btn-info\">Comprar</button>\n            </td>\n        </tr>\n");
#nullable restore
#line 63 "C:\Users\BSBO\Desktop\Final\CasaDeShow\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CasaDeShow.Models.Evento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
