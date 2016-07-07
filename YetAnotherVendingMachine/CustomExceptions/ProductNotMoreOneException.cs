using System;

namespace YetAnotherVendingMachine
{
    internal class ProductNotMoreOneException : Exception
    {
        public ProductNotMoreOneException()
        {
        }

        public ProductNotMoreOneException(string message)
            : base(message)
        {
        }

        public ProductNotMoreOneException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
