using BankMore.Account.Application.Features.Moviment.Commands;
using BankMore.Account.Application.Features.Moviment.Responses;
using BankMore.Account.Domain.MovimentAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Moviment.Handlers
{
    public class MovimentCommandHandler : IRequestHandler<DepositCommand, DepositResponse>,
                                          IRequestHandler<WithdrawCommand, WithdrawResponse>
    {
        private readonly IMovimentRepository _repository;

        public MovimentCommandHandler(IMovimentRepository repository)
        {
            _repository = repository;
        }

        public async Task<DepositResponse> Handle(DepositCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.AccountNumber))
            {
                throw new ArgumentException("Numero da conta vazio");
            }

            if (command.Value <= ushort.MinValue)
            {
                throw new ArgumentException("Valor do deposito precisa ser maior que 0");
            }

            await _repository.Deposit(command.AccountNumber, command.Value);

            return new DepositResponse(command.Value);
        }

        public async Task<WithdrawResponse> Handle(WithdrawCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.AccountNumber))
            {
                throw new ArgumentException("Numero da conta vazio");
            }

            if (command.Amount <= ushort.MinValue)
            {
                throw new ArgumentException("Valor de saque precisa ser maior que 0");
            }

            await _repository.Withdraw(command.AccountNumber, command.Amount);

            return new WithdrawResponse(command.Amount);
        }
    }
}
