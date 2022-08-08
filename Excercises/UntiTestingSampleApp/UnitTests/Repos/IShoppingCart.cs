using System.Collections.Generic;

namespace UnitTests
{

    // ShoppingCart that should be tested by unit tests that you need to prepare.
    public interface IShoppingCart
    {
        // Add requested quantity of product to shoppingCart
        void AddProduct(int productId, int quantity);
        // Remove requested quantity of product from shoppingCart
        void RemoveProduct(int productId, int quantity);
        // Get ShoppingCart items and their quantity
        IList<ShoppingCartItem> GetShoppingCartItems();
        // Get total value of ShoppingCart (sum of Quantity*UnitPrice for each added product)
        int GetTotal();
        // Clear shopping cart
        void Clear();
    }
}