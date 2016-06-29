using System;

namespace YetAnotherVendingMachine
{
    internal class WrongCoinsException : ArgumentOutOfRangeException
    {
        public WrongCoinsException() : base("You insert wrong coin")
        {
        }
    }
}
