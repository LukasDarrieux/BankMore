using BankMore.Transfer.Application.Feature.Transference.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Transfer.Application.Feature.Transference.Commands
{
    public record TransferenceCommand : IRequest<TransferenceResponse>
    {
        public string IdAccountOrigin { get; set; }
        public string IdAccountDestiny { get; set; }
        public decimal Value { get; set; }
    }
}
