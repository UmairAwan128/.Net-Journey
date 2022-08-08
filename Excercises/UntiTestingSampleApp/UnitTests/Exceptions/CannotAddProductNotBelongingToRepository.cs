using System;

namespace UnitTests
{
    public class CannotAddProductNotBelongingToRepository : Exception
    {
        public CannotAddProductNotBelongingToRepository()
        {
        }

        public CannotAddProductNotBelongingToRepository(string message)
            : base(message)
        {
        }

        public CannotAddProductNotBelongingToRepository(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}