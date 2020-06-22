#pragma checksum "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04db3c0a234d7d2b3daf7ef504dd9487cf962571"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_CriarConta), @"mvc.1.0.view", @"/Views/Usuario/CriarConta.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/CriarConta.cshtml", typeof(AspNetCore.Views_Usuario_CriarConta))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04db3c0a234d7d2b3daf7ef504dd9487cf962571", @"/Views/Usuario/CriarConta.cshtml")]
    public class Views_Usuario_CriarConta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Projeto.Presentation.Models.CriarContaModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
  
    ViewData["Title"] = "CriarConta";
    Layout = "~/Views/Templates/Layout.cshtml";

#line default
#line hidden
            BeginContext(147, 87, true);
            WriteLiteral("\r\n<h4>Criar conta de Usuário</h4>\r\n<a href=\"/Home/Index\">Página Inicial</a>\r\n<hr />\r\n\r\n");
            EndContext();
#line 11 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
 using (Html.BeginForm("CriarConta", "Usuario", FormMethod.Post, new { @enctype = "multipart/form-data" }))
{

#line default
#line hidden
            BeginContext(346, 39, true);
            WriteLiteral("    <div class=\"text-danger\">\r\n        ");
            EndContext();
            BeginContext(386, 24, false);
#line 14 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
   Write(Html.ValidationSummary());

#line default
#line hidden
            EndContext();
            BeginContext(410, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
            BeginContext(426, 37, true);
            WriteLiteral("    <label>Nome do Usuário:</label>\r\n");
            EndContext();
            BeginContext(468, 78, false);
#line 18 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
Write(Html.TextBoxFor(model => model.Nome, new { @class = "form-control col-md-4" }));

#line default
#line hidden
            EndContext();
            BeginContext(548, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(562, 37, true);
            WriteLiteral("    <label>Email de Acesso:</label>\r\n");
            EndContext();
            BeginContext(604, 79, false);
#line 22 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
Write(Html.TextBoxFor(model => model.Email, new { @class = "form-control col-md-4" }));

#line default
#line hidden
            EndContext();
            BeginContext(685, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(699, 27, true);
            WriteLiteral("    <label>Senha:</label>\r\n");
            EndContext();
            BeginContext(731, 80, false);
#line 26 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
Write(Html.PasswordFor(model => model.Senha, new { @class = "form-control col-md-4" }));

#line default
#line hidden
            EndContext();
            BeginContext(813, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(827, 38, true);
            WriteLiteral("    <label>Confirme a Senha:</label>\r\n");
            EndContext();
            BeginContext(870, 91, false);
#line 30 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
Write(Html.PasswordFor(model => model.SenhaConfirmacao, new { @class = "form-control col-md-4" }));

#line default
#line hidden
            EndContext();
            BeginContext(963, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(977, 51, true);
            WriteLiteral("    <label>Selecione o Perfil do Usuário:</label>\r\n");
            EndContext();
            BeginContext(1033, 153, false);
#line 34 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
Write(Html.DropDownListFor(model => model.IdPerfil, Model.ListagemDePerfis,
                    "Escolha uma opção", new { @class = "form-control col-md-4" }));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
            BeginContext(1202, 114, true);
            WriteLiteral("    <label>Envie a foto:</label>\r\n    <input type=\"file\" name=\"foto\" class=\"form-control col-md-4\"/>\r\n    <br />\r\n");
            EndContext();
            BeginContext(1318, 103, true);
            WriteLiteral("    <input type=\"submit\" class=\"btn btn-success\" value=\"Cadastrar Usuário\" />\r\n    <br />\r\n    <br />\r\n");
            EndContext();
            BeginContext(1423, 12, true);
            WriteLiteral("    <strong>");
            EndContext();
            BeginContext(1436, 20, false);
#line 46 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
       Write(TempData["Mensagem"]);

#line default
#line hidden
            EndContext();
            BeginContext(1456, 11, true);
            WriteLiteral("</strong>\r\n");
            EndContext();
            BeginContext(1469, 39, true);
            WriteLiteral("    <div class=\"text-danger\">\r\n        ");
            EndContext();
            BeginContext(1509, 26, false);
#line 49 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
   Write(TempData["MensagemUpload"]);

#line default
#line hidden
            EndContext();
            BeginContext(1535, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 51 "C:\Users\windows\Desktop\002\Coti\ProjetoTesteAula17\Projeto.Presentation\Views\Usuario\CriarConta.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Projeto.Presentation.Models.CriarContaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
