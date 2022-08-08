using System.Collections.Generic;

namespace UnitTests
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
    }
}