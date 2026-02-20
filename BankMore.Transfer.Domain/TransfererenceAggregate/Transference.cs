using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Transfer.Domain.TransferenceAggregate
{
    public class Transference
    {
        public Guid IdTranference { get; set; }
        public Guid IdAccountOrigin { get; set;  }
        public Guid IdAccountDestiny { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set;  }
    }
}
