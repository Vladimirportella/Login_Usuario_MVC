using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Validations
{
    public class SenhaValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                var senha = value.ToString();
                return senha.Any(char.IsDigit) &&
                       senha.Any(char.IsUpper) &&
                       senha.Any(char.IsLower) &&
                       (senha.Contains("@")
                        || senha.Contains("&")
                        || senha.Contains("#")
                        || senha.Contains("%"));
            }
            return false;
        }
    }
}
