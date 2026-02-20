using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Moviment.Responses
{
    public class DepositResponse
    {
        public decimal Value { get; set;  }

        public DepositResponse(decimal value)
        {
            Value = value;
        }
    }
}
