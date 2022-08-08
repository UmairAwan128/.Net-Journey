using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public abstract class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //ShoppingCartUnitTests shoppingCartUnitTests = new ShoppingCartUnitTests();
            //shoppingCartUnitTests
        }

    }

    public partial class ShoppingCartUnitTests
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartUnitTests(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public void AddProduct(int productId, int quantity)
        {
            if (quantity < 0)
            {
                Assert.ThrowsException<QuantityCannotBeNegativeException>(null,"asd");
            }

            // Perform operations on '_shoppingCart'
            _shoppingCart.AddProduct(1, 2);

            // And assert
            Assert.ThrowsException<CannotAddProductNotBelongingToRepository>(null);
        }

        public void Clear()
        {
            _shoppingCart.Clear();
        }

        public void GetShoppingCartItems()
        {
            _shoppingCart.Clear();
        }

        public int GetTotal()
        {
            _shoppingCart.GetTotal();
        }

        public void RemoveProduct(int productId, int quantity)
        {
            if (quantity < 0)
            {
                Assert.ThrowsException<QuantityCannotBeNegativeException>(null, "asd");
            }

            _shoppingCart.RemoveProduct(productId, quantity);

            // And assert
            Assert.ThrowsException<CannotRemoveHigherQuantityThanAddedException>(null);
        }


        public void ShoppingCartShouldBeImplemented()
        {
            // TODO - Assertions
            //Assert.Throws<Exception>((msg) =>  );
            //Assert.True(value);
            //Assert.False(value);
            //Assert.Equal(expected, actual);
            //Assert.NotEqual(expected, actual);
        }

        public class ProductRepository : IProductRepository
        {
            public IList<Product> GetProducts()
            {
                throw new NotImplementedException();
            }
        }
        public class ShoppingCart : IShoppingCart
        {
            public void AddProduct(int productId, int quantity)
            {

            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public IList<ShoppingCartItem> GetShoppingCartItems()
            {
                throw new NotImplementedException();
            }

            public int GetTotal()
            {
                throw new NotImplementedException();
            }

            public void RemoveProduct(int productId, int quantity)
            {
                throw new NotImplementedException();
            }
        }
    }
}