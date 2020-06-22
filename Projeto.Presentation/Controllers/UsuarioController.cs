using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Cryptography.Services;
using Projeto.Data.Entities;
using Projeto.Data.Repositories;
using Projeto.Messages.Services;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    public class UsuarioController : Controller
    {

        private IHostingEnvironment hostingEnvironment;

        public UsuarioController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult CriarConta()
        {
            return View(new CriarContaModel());
        }

        [HttpPost]
        public IActionResult CriarConta(CriarContaModel model)
        {
            if (ModelState.IsValid)
            {
                var files = Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var extensao = Path.GetExtension(files.First().FileName);

                    if (extensao.Equals(".jpg") || extensao.Equals(".jpeg") || extensao.Equals(".png"))
                    {
                        try
                        {
                            var md5 = new MD5Service();

                            var usuario = new Usuario();
                            usuario.Nome = model.Nome;
                            usuario.Email = model.Email;
                            usuario.Senha = md5.Encriptar(model.Senha);
                            usuario.DataCriacao = DateTime.Now;
                            usuario.Foto = "/imagens/usuarios/" + usuario.Email + extensao;
                            usuario.IdPerfil = model.IdPerfil;

                            var repository = new UsuarioRepository();
                            repository.Inserir(usuario);

                            using(var stream = new FileStream(hostingEnvironment.WebRootPath + usuario.Foto, FileMode.Create)) 
                            {
                                files.First().CopyTo(stream);
                            }

                            TempData["Mensagem"] = "Usuário cadastrado com sucesso.";
                            ModelState.Clear();

                            //EnviarMensagem(usuario);
                        }
                        catch (Exception e)
                        {
                            TempData["Mensagem"] = e.Message;                        }
                    }
                    else
                    {
                        TempData["Mensagem"] = "Envie apenas arquivos de extensão jpg, jpeg ou png.";
                    }

                }
                else
                {
                    TempData["Mensagem"] = "Por favor, envie a foto do usuário.";
                }

            }
            return View(new CriarContaModel());
        }

        public IActionResult Autenticar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(AutenticarModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var criptografia = new MD5Service();
                    var usuarioRepository = new UsuarioRepository();
                    var usuario = usuarioRepository.Consultar
                        (model.Email, criptografia.Encriptar(model.Senha));

                    if (usuario != null)
                    {
                        var perfilRepository = new PerfilRepository();
                        var perfil = perfilRepository.ObterPorId(usuario.IdPerfil);

                        var credenciais = new ClaimsIdentity(
                            new[]
                            {
                                new Claim(ClaimTypes.Name, usuario.Email),
                                new Claim(ClaimTypes.Role, perfil.Nome)
                            }, 
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        var acesso = new ClaimsPrincipal(credenciais);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, acesso);

                        HttpContext.Session.SetString("Nome", usuario.Nome);
                        HttpContext.Session.SetString("Email", usuario.Email);
                        HttpContext.Session.SetString("Perfil", perfil.Nome);
                        HttpContext.Session.SetInt32("IdPerfil", usuario.IdPerfil);
                        HttpContext.Session.SetString("Foto", usuario.Foto);

                        switch (perfil.Nome)
                        {
                            case "Pessoa Física":
                                return RedirectToAction("Index","PessoaFisica");

                            case "Pessoa Jurídica":
                                return RedirectToAction("Index", "PessoaJuridica");
                        }
                    }
                    else
                    {
                        TempData["Mensagem"] = "Acesso Negado. Usuário não foi encontrado.";
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            return View();
        }

        private void EnviarMensagem(Usuario usuario) 
        {
            var destinatario = usuario.Email;
            var assunto = "Conta de usuário criada com sucesso.";
            var mensagem = "Olá " + usuario.Nome + "\n\n"
                            + "Sua conta de usuário foi criada com sucesso.\n";

            var service = new EmailService();
            service.EnviarMensagem(destinatario, assunto, mensagem);
        }

        public IActionResult Logout() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("Nome");
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Remove("Perfil");
            HttpContext.Session.Remove("IdPerfil");
            HttpContext.Session.Remove("Foto");

            return RedirectToAction("Index","Home");
        }

    }
}