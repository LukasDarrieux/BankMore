using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Domain.MovimentAggregate
{
    public class Moviment
    {
        public Guid IdMoviment { get; set;  }
        public Guid IdAccount { get; set;  } 
        public EnumTypeMoviment Type { get;set;  }
        public decimal Value { get; set; }

    }
}
