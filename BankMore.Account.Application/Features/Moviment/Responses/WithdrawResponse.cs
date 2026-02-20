using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Moviment.Responses
{
    public class WithdrawResponse
    {
        public decimal Amount { get; set; }

        public WithdrawResponse(decimal amount) 
        {
            Amount = amount;
        }
    }
}
