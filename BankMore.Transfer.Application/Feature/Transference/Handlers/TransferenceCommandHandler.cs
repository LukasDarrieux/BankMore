

using BankMore.Transfer.Application.Feature.Transference.Commands;
using BankMore.Transfer.Application.Feature.Transference.Response;
using BankMore.Transfer.Domain.TransfererenceAggregate.Repository;
using MediatR;

namespace BankMore.Transfer.Application.Feature.Transference.Handlers
{
    public class TransferenceCommandHandler : IRequestHandler<TransferenceCommand, TransferenceResponse>
    {
        private readonly ITransferenceRepository _repository;

        public TransferenceCommandHandler(ITransferenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<TransferenceResponse> Handle(TransferenceCommand command, CancellationToken cancellationToken)
        {
            var transference = new Domain.TransferenceAggregate.Transference()
            {
                IdTranference = new Guid(),
                IdAccountDestiny = new Guid(command.IdAccountDestiny),
                IdAccountOrigin = new Guid(command.IdAccountOrigin),
                Value = command.Value,
                Date = DateTime.Now
            };


            await _repository.Execute(transference);

            return new TransferenceResponse();
        }

    }
    
}
