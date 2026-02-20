using BankMore.Account.Application.Features.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Commands
{
    public record InactiveAccountCommand : IRequest<InactiveResponse>
    {
        public string AccountNumberOrCPF { get; set;  }
        public string Password { get; set; }
    }
}
