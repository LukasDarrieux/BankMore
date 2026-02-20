using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Transfer.Application.Feature.Transference.Response
{
    public class TransferenceResponse
    {
        public string IdAccountOrigin { get; set; }
        public string IdAccountDestiny { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
