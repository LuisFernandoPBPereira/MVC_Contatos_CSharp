﻿using System.Security.Cryptography;
using System.Text;

namespace CrudMVC.Helper
{
    public static class Criptografia
    {
        //Criamos o método para gerar a criptografia de senha
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);
            
            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
