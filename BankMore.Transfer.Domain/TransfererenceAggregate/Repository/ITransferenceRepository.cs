using BankMore.Transfer.Domain.TransferenceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Transfer.Domain.TransfererenceAggregate.Repository
{
    public interface ITransferenceRepository
    {
        Task Execute(Transference transference);
    }
}
