using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Data.Repositories;
using Projeto.Presentation.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Models
{
    public class CriarContaModel
    {
        [Required(ErrorMessage ="Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailUnicoValidation(ErrorMessage ="O email informado já encontra-se cadastrado no sistema.")]
        [EmailAddress(ErrorMessage ="Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [SenhaValidation(ErrorMessage = "A Senha deve conter pelo menos 1 dígito numérico, " 
                                + "letras maiúsculas e minúsculas e também 1 caractere especial: @, #, %, & ")]
        [MinLength(6, ErrorMessage ="A senha deve conter no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage ="A senha deve conter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage ="Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a senha.")]
        public string SenhaConfirmacao { get; set; }

        public int IdPerfil { get; set; }

        public List<SelectListItem> ListagemDePerfis 
        {
            get 
            {
                var listagem = new List<SelectListItem>();
                var repository = new PerfilRepository();
                var perfis = repository.Consultar();

                foreach (var item in perfis)
                {
                    listagem.Add(new SelectListItem
                    {
                        Value = item.IdPerfil.ToString(),
                        Text = item.Nome
                    });
                }

                return listagem;
            } 
        }
    }
}
