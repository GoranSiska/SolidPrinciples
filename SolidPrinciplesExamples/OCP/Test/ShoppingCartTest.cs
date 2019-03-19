using NUnit.Framework;
using System.Collections.Generic;

namespace SolidPrinciplesExamples.OCP.Test
{
    [TestFixture]
    public class BadShoppingCartTest
    {
        [Test]
        public void GivenShoppingCart_WhenCalculatingTotal_ReturnsCorrectPrice()
        {
            var products = new List<Bad.Product>
            {
                new Bad.Product { Price = 9m },
                new Bad.ProductWithDiscount { Price = 10m, Discount = 0.1m }
            };
            var shoppingCart = new Bad.ShoppingCart();

            var total = shoppingCart.CalculateTotal(products);

            Assert.AreEqual(10, total);
        }
    }

    [TestFixture]
    public class GoodShoppingCartTest
    {

        [Test]
        public void GivenShoppingCart_WhenCalculatingTotal_ReturnsCorrectPrice()
        {
            var products = new List<Good.Product>
            {
                new Good.Product { Price = 9m },
                new Good.ProductWithDiscount { Price = 10m, Discount = 0.1m },
                new Good.ProductWithSurcharge {Price = 5m, Surcharge = 5m}
            };
            var shoppingCart = new Good.ShoppingCart();

            var total = shoppingCart.CalculateTotal(products);

            Assert.AreEqual(20, total);
        }
    }
}
