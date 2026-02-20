using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Responses
{
    public class NewAccountResponse
    {
        public int AccountNumber { get; set; }

        public NewAccountResponse(int accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}
