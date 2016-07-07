using System;

namespace YetAnotherVendingMachine
{
    internal class ProductValidateException : Exception
    {
        public ProductValidateException()
        {
        }

        public ProductValidateException(string message)
            : base(message)
        {
        }

        public ProductValidateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}