using System;

namespace YetAnotherVendingMachine
{
    internal class WrongCoinsException : Exception
    {
        public WrongCoinsException()
        {
        }

        public WrongCoinsException(string message)
            : base(message)
        {
        }

        public WrongCoinsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
