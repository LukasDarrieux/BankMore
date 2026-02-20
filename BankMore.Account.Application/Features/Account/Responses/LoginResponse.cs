using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string AccountNumber { get; set;  }

        public LoginResponse(string token, string accountNumber)
        {
            this.Token = token;
            this.AccountNumber = accountNumber;
        }
    }
}
