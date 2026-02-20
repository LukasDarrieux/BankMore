using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Application.Features.Account.Responses
{
    public class InactiveResponse
    {
        public bool active { get; private set;  }
        public InactiveResponse() {
            active = false;
        }
    }
}
