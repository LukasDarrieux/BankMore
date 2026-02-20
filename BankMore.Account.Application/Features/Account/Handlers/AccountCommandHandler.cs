using BankMore.Account.Application.Features.Account.Commands;
using BankMore.Account.Application.Features.Account.Responses;
using BankMore.Account.Domain.AccountAggregate.Repositories;
using MediatR;

namespace BankMore.Account.Application.Features.Account.Handlers
{
    public class AccountCommandHandler : IRequestHandler<LoginCommand, LoginResponse>,
                                         IRequestHandler<NewAccountCommand, NewAccountResponse>,
                                         IRequestHandler<InactiveAccountCommand, InactiveResponse>
    {

        private readonly IAccountRepository _repository;

        public AccountCommandHandler(IAccountRepository repository) 
        {
            _repository = repository;
        }

        public async Task<NewAccountResponse> Handle(NewAccountCommand command, CancellationToken cancellationToken)
        {

            if (!GlobalFunctions.CPFValidate(command.CPF))
            {
                throw new ArgumentException("CPF inválido.");
            }

            var account = new Domain.AccountAggregate.Account() {
                Name = command.Name, 
                CPF = command.CPF, 
                Password = command.Password
            };

            account.Id = Guid.NewGuid();
            account.Active = true;
            account.Balance = 0m;


            var numeroConta = await _repository.CreateAsync(account);

            return new NewAccountResponse(numeroConta);
        }

        public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            if (command.AccountNumberOrCPF.Length == 11)
            {
                if (!GlobalFunctions.CPFValidate(command.AccountNumberOrCPF))
                {
                    throw new ArgumentException("CPF inválido.");
                }
            }

            var account = await _repository.GetByNumberOrCPFAsync(command.AccountNumberOrCPF);
            
            return new LoginResponse("");
            
        }

        public async Task<InactiveResponse> Handle(InactiveAccountCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.AccountNumberOrCPF))
            {
                throw new ArgumentException("Informe o numero da conta ou CPF do titular");
            }

            if (command.AccountNumberOrCPF.Length == 11)
            {
                if (!GlobalFunctions.CPFValidate(command.AccountNumberOrCPF))
                {
                    throw new ArgumentException("CPF inválido.");
                }
            }

            var account = await _repository.GetByNumberOrCPFAsync(command.AccountNumberOrCPF);
                
            if (account.Password != command.Password)
            {
                throw new ArgumentException("Senha inválida");
            }

            await _repository.DeactivateAsync(account.Id);

            return new InactiveResponse();
        }
    }
}
