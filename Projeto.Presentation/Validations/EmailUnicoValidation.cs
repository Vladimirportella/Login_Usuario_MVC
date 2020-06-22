using Projeto.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Validations
{
    public class EmailUnicoValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                var email = value.ToString();

                var repostitory = new UsuarioRepository();
                var usuario = repostitory.Consultar(email);

                return usuario == null;
            }
            return false;
        }
    }
}
