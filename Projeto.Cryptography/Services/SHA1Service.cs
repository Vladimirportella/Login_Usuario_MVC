using Projeto.Cryptography.Contracts;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.Cryptography.Services
{
    public class SHA1Service : ISHA1Service
    {
        public string Encriptar(string valor)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(valor));

            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("x2");
            }

            return result;
        }
    }
}
