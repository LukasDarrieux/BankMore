using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application
{
    public class GlobalFunctions
    {
        public static bool CPFValidate(string cpf)
        {
            short[] multiplicador1 = new short[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            short[] multiplicador2 = new short[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string auxCPF, digito;
            int soma = 0;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "").Replace(",", "");

            if (cpf.Length < 11) return false;

            auxCPF = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
            {
                soma += short.Parse(auxCPF[i].ToString()) * multiplicador1[i];
            }

            int resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();

            auxCPF = auxCPF + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += short.Parse(auxCPF[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            auxCPF = auxCPF + resto;

            if (cpf != auxCPF) return false;
            return true;
        }
    }
}
