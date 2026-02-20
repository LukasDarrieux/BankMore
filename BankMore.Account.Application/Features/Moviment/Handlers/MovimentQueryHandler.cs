using BankMore.Account.Application.Features.Account.Queries;
using BankMore.Account.Domain.MovimentAggregate;
using BankMore.Account.Domain.MovimentAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Moviment.Handlers
{
    public class MovimentQueryHandler : IRequestHandler<GetAccountBalanceQuery, decimal>
    {
        private readonly IMovimentRepository _repository;

        public MovimentQueryHandler(IMovimentRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
        {
            decimal balance = ushort.MinValue;

            var moviments = await _repository.GetMoviments(request.AccountNumber);

            List<Domain.MovimentAggregate.Moviment> listMoviment = moviments.ToList();

            if (listMoviment.Count > ushort.MinValue)
            {
                foreach (var moviment in listMoviment)
                {
                    if (moviment.Type.Equals(EnumTypeMoviment.Credit))
                    {
                        balance += moviment.Value;
                    }
                    else
                    {
                        balance -= moviment.Value;
                    }
                }
            }

            return balance;

        }
    }
}
