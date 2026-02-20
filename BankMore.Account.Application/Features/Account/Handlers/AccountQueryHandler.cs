using BankMore.Account.Application.Features.Account.Queries;
using BankMore.Account.Domain.AccountAggregate.Repositories;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Handlers
{
    public class AccountQueryHandler : IRequestHandler<GetAccountBalanceQuery, decimal>
    {
        private readonly IAccountRepository _repository;

        public AccountQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
        {
            var balance = await _repository.GetBalance(request.AccountNumberOrCPF);

            if (balance is null)
            {
                throw new Exception("Conta não encontrada");
            }

            return balance.Value;
        }
    }
}
