using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Domain.MovimentAggregate.Repositories
{
    public interface IMovimentRepository
    {
        Task Deposit(string numberAccount, decimal value);

        Task Withdraw(string numberAccount, decimal amount);

        Task<IEnumerable<Moviment>> GetMoviments(string numberAccount);
    }
}
