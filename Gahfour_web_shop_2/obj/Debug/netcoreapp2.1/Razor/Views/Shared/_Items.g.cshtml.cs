#pragma checksum "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Shared\_Items.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44207615181100512426408ccf58566e3fc35693"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Items), @"mvc.1.0.view", @"/Views/Shared/_Items.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Items.cshtml", typeof(AspNetCore.Views_Shared__Items))]
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
#line 1 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\_ViewImports.cshtml"
using Gahfour_web_shop_2;

#line default
#line hidden
#line 2 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\_ViewImports.cshtml"
using Gahfour_web_shop_2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44207615181100512426408ccf58566e3fc35693", @"/Views/Shared/_Items.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a08a05b659dbb52595f871c2a419708ee074a827", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Items : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(3868, 11, true);
            WriteLiteral("\r\n<table>\r\n");
            EndContext();
#line 96 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Shared\_Items.cshtml"
       
        int counter = 0;
        int rowCount = 0;
    

#line default
#line hidden
            BeginContext(3948, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 100 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Shared\_Items.cshtml"
         foreach (var item in Model)
        {
            if(rowCount == 0)
            {

#line default
#line hidden
            BeginContext(4043, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(4061, 6, true);
            WriteLiteral("<tr>\r\n");
            EndContext();
#line 105 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Shared\_Items.cshtml"
            }

#line default
#line hidden
            BeginContext(4082, 32, true);
            WriteLiteral("            <td>item.name</td>\r\n");
            EndContext();
#line 107 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Shared\_Items.cshtml"
            counter++;
            rowCount++;
            if(rowCount == ViewBag.myCols){
                    rowCount = 0;
            }
        }

#line default
#line hidden
            BeginContext(4269, 8, true);
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
