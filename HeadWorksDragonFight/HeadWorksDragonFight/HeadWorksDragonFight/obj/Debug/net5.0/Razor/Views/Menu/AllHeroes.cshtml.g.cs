#pragma checksum "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cf590d04ce1d0c18e1717882ed405471cd719bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_AllHeroes), @"mvc.1.0.view", @"/Views/Menu/AllHeroes.cshtml")]
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
#line 1 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\_ViewImports.cshtml"
using HeadWorksDragonFight;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\_ViewImports.cshtml"
using HeadWorksDragonFight.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cf590d04ce1d0c18e1717882ed405471cd719bf", @"/Views/Menu/AllHeroes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58412c0a26156ccb16ea112a62d9008296becd29", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_AllHeroes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HeadWorksDragonFight.Core.Models.Hero>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Heroes</h2>\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 11 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 14 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayNameFor(model => model.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 17 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayNameFor(model => model.Weapon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 20 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 26 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <th>\n                ");
#nullable restore
#line 30 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <td>\n                ");
#nullable restore
#line 33 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 36 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Weapon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 39 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n\n        </tr>\n");
#nullable restore
#line 43 "C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\HeadWorksDragonFight\Views\Menu\AllHeroes.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HeadWorksDragonFight.Core.Models.Hero>> Html { get; private set; }
    }
}
#pragma warning restore 1591
