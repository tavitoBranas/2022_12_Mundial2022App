#pragma checksum "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90e6e733adeb4bfa7c333518f8a529858dde2365"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ListadoSelecciones), @"mvc.1.0.view", @"/Views/Home/ListadoSelecciones.cshtml")]
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
#line 1 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\_ViewImports.cshtml"
using AppMundial;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\_ViewImports.cshtml"
using AppMundial.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90e6e733adeb4bfa7c333518f8a529858dde2365", @"/Views/Home/ListadoSelecciones.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d843c96aade944b61b8fb23ecd8b7d3cf2a607cb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ListadoSelecciones : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PrimerObligatorio.Seleccion>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""text-center  "">
    <br /><h2>Listado de selecciones con sus respectivos jugadores</h2><br />

    <table class=""table justify-content-around align-items-center"">
        <thead>
            <tr>
                <td class=""col-1 col-sm-1""></td>
                <td class=""col-1 col-sm-1""></td>
                <td class=""col-1 col-sm-1""></td>
                <td class=""col-1 col-sm-1""></td>
                <td class=""col-1 col-sm-1""></td>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
             foreach (var Seleccion in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <tr>
                    <td class=""col-1 col-sm-1"" style=""background-color:lightgreen""></td>
                    <td class=""col-1 col-sm-1"" style=""background-color:lightgreen""></td>
                    <td class=""col-1 col-sm-1"" style=""background-color:lightgreen""> ");
#nullable restore
#line 22 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                                                                               Write(Seleccion.Pais.NombrePais);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"col-1 col-sm-1\" style=\"background-color:lightgreen\"></td>\r\n                    <td class=\"col-1 col-sm-1\" style=\"background-color:lightgreen\"></td>\r\n                </tr>\r\n");
#nullable restore
#line 26 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"

                int contador = 0;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                 foreach (var jugador in Seleccion.GetJugadoresSeleccion())
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                     if ( contador ==5)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr></tr>\r\n");
#nullable restore
#line 33 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                        ;
                        contador=0;
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                     if (contador <= 5 )
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 39 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                   Write(jugador.NombreCompJugador);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 40 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                    contador++; 
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Home\ListadoSelecciones.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PrimerObligatorio.Seleccion>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591