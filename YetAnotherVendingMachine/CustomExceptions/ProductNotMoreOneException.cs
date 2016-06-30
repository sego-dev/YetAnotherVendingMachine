using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherVendingMachine
{
    class ProductNotMoreOneException : InvalidOperationException
    {
        public ProductNotMoreOneException() : base("You can't buy product twice")
        {
            
        }
    }
}
