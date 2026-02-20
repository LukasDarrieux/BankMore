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
    public record LoginCommand : IRequest<LoginResponse>
    {
        [Description("Account number or CPF")]
        public string AccountNumberOrCPF { get; set; }

        [Description("Account Password")]
        public string Password { get; set; }
        
    }
}
