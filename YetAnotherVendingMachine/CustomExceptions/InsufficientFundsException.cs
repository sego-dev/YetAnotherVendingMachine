using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherVendingMachine
{
    class InsufficientFundsException : InvalidOperationException
    {
        public InsufficientFundsException() : base("Insufficient funds")
        {
            
        }
    }
}
