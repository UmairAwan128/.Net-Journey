using System;

namespace UnitTests
{
    public class CannotRemoveHigherQuantityThanAddedException : Exception
    {
        public CannotRemoveHigherQuantityThanAddedException()
        {
        }

        public CannotRemoveHigherQuantityThanAddedException(string message)
            : base(message)
        {
        }

        public CannotRemoveHigherQuantityThanAddedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}