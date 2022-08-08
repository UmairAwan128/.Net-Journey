using System;

namespace UnitTests
{
    public class HigherQuantityAddedThanAvailableException : Exception
    {
        public HigherQuantityAddedThanAvailableException()
        {
        }

        public HigherQuantityAddedThanAvailableException(string message)
            : base(message)
        {
        }

        public HigherQuantityAddedThanAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}