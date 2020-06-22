﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Models
{
    public class AutenticarModel
    {
        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }
}
