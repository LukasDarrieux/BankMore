using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Domain.AccountAggregate.Repositories
{
    public interface IAccountRepository
    {
        Task<int> CreateAsync(Account account);

        Task<Account?> GetByNumberOrCPFAsync(string numberOrCPF);

        Task DeactivateAsync(Guid id);

    }
}
