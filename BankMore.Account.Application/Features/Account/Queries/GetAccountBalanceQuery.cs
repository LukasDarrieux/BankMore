using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Queries
{
    public class GetAccountBalanceQuery : IRequest<decimal> 
    {
        public string AccountNumberOrCPF { get; set; }

        public GetAccountBalanceQuery(string accoutNumberOrCPF)
        {
            AccountNumberOrCPF = accoutNumberOrCPF;
        }
    }
}
