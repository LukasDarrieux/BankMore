using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Domain.AccountAggregate
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Number { get; set;  }
        public string Name { get; set; }
        public string CPF { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }

    }
}
