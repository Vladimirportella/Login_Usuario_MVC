using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Entities;
using Projeto.Data.Repositories;

namespace Projeto.Presentation.Controllers
{
   [Authorize(Roles ="Pessoa Física")]
    public class PessoaFisicaController : Controller
    {
        public IActionResult Index()
        {
            var lista = new List<Usuario>();

            try
            {
                var repository = new UsuarioRepository();
                var idPerfil = Convert.ToInt32(HttpContext.Session.GetInt32("IdPerfil"));
                lista = repository.Consultar(idPerfil);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            return View(lista);
        }
    }
}