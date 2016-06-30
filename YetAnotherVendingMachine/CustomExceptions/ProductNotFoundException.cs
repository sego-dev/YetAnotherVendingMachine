using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherVendingMachine
{
    class ProductNotFoundException : InvalidOperationException
    {
        public ProductNotFoundException() : base("Product not found")
        {
            
        }
    }
}
