using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherVendingMachine
{
    class ProductNotAvailableException : InvalidOperationException
    {
        public ProductNotAvailableException() : base("Product not available")
        {
            
        }
    }
}
