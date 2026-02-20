using BankMore.Account.Application.Features.Moviment.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Moviment.Commands
{
    public record WithdrawCommand : IRequest<WithdrawResponse>
    {
        [Description("Account number")]
        public string AccountNumber { get; set;  }

        [Description("Withdraw amount")]
        public decimal Amount { get;set;  }
    }
}
