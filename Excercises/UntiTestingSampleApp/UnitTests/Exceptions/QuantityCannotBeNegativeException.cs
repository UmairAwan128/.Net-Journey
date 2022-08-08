using System;

namespace UnitTests
{
    // This exception should be thrown once ShoppingCart conditions are not fulfilled
    public class QuantityCannotBeNegativeException : Exception
    {
        public QuantityCannotBeNegativeException()
        {
        }

        public QuantityCannotBeNegativeException(string message)
            : base(message)
        {
        }

        public QuantityCannotBeNegativeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}