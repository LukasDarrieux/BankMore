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
    public record DepositCommand : IRequest<DepositResponse>
    {
        [Description("Account number")]
        public string AccountNumber { get;set;  }

        [Description("Deposit value")]
        public decimal Value { get;set; }
    }
}
