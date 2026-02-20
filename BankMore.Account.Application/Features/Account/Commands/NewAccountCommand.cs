using BankMore.Account.Application.Features.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Commands
{
    public record NewAccountCommand : IRequest<NewAccountResponse>
    {
        [Description("Account Name")]
        public string Name { get;set;  }

        [Description("Account CPF (Cadastro de Pessoa Física)")]
        public string CPF { get; set; }

        [Description("Account Password")]
        public string Password { get; set; }

    }
}
