#pragma checksum "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcbe4e34ce37b273e65100e901ac965c753c6c98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_Details), @"mvc.1.0.view", @"/Views/Item/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Item/Details.cshtml", typeof(AspNetCore.Views_Item_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcbe4e34ce37b273e65100e901ac965c753c6c98", @"/Views/Item/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a08a05b659dbb52595f871c2a419708ee074a827", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Item>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(75, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            BeginContext(84, 74, true);
            WriteLiteral("<div id=\"content\" class=\"item-details\">\r\n    <h2 title=\"Artikel fullnamn\">");
            EndContext();
            BeginContext(159, 15, false);
#line 9 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml"
                            Write(Model.Full_Name);

#line default
#line hidden
            EndContext();
            BeginContext(174, 20, true);
            WriteLiteral("</h2>\r\n    <p>Name: ");
            EndContext();
            BeginContext(195, 16, false);
#line 10 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml"
        Write(ViewData["name"]);

#line default
#line hidden
            EndContext();
            BeginContext(211, 14, true);
            WriteLiteral("</p>\r\n    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 225, "\"", 261, 2);
            WriteAttributeValue("", 231, "../../images/", 231, 13, true);
#line 11 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml"
WriteAttributeValue("", 244, Model.Image_File, 244, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(262, 12, true);
            WriteLiteral(" />\r\n    <p>");
            EndContext();
            BeginContext(275, 17, false);
#line 12 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml"
  Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(292, 13, true);
            WriteLiteral("</p>\r\n    <p>");
            EndContext();
            BeginContext(306, 11, false);
#line 13 "C:\Users\Emanuel\source\repos\Gahfour_web_shop_2\Gahfour_web_shop_2\Views\Item\Details.cshtml"
  Write(Model.Price);

#line default
#line hidden
            EndContext();
            BeginContext(317, 64, true);
            WriteLiteral("</p>\r\n    <p><a href=\"#\">Lägg i varukorg</a></p>\r\n\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
