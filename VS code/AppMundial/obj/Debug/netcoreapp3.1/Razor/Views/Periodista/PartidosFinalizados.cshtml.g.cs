#pragma checksum "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ab8e4e0b7a09d1567d820d14d275e4968db86c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Periodista_PartidosFinalizados), @"mvc.1.0.view", @"/Views/Periodista/PartidosFinalizados.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab8e4e0b7a09d1567d820d14d275e4968db86c4", @"/Views/Periodista/PartidosFinalizados.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d843c96aade944b61b8fb23ecd8b7d3cf2a607cb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Periodista_PartidosFinalizados : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PrimerObligatorio.Partido>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <br /><h2>Partidos finalizados</h2><br /><br />\r\n\r\n");
#nullable restore
#line 6 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
     if(Model.Count() != 0){

   

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <td><b>Fecha de partido</b></td>
                <td> <b>Selección </b></td>
                <td> <b>Selección </b></td>
                <td> <b>Ganador </b></td>
                <td> </td>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 20 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
             foreach (var partido in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 23 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
                   Write(partido.FechaPartido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 24 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
                     foreach (var Seleccion in partido.GetSeleccionesPartido())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 26 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
                       Write(Seleccion.Pais.NombrePais);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 27 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <!--con esta etiqueta html.raw leo el texto con <br/> para salto de linea-->\r\n                    <td>");
#nullable restore
#line 29 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
                   Write(partido.ResultadoFinal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <!--link para la reseña-->\r\n                    <td>");
#nullable restore
#line 31 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
                   Write(Html.ActionLink("Realizar reseña","Reseña",new{id=partido.IdPartido}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 36 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
    } 
    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p><b>No existen partidos finalizados</b></p>\r\n");
#nullable restore
#line 39 "D:\Estudio\ORT\2S\P2\Obligatorio\Segundo Obligatorio\AppMundial\Views\Periodista\PartidosFinalizados.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PrimerObligatorio.Partido>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
