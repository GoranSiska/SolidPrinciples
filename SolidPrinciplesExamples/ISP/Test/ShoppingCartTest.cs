using NUnit.Framework;
using System.Collections.Generic;

namespace SolidPrinciplesExamples.ISP.Test
{
    [TestFixture]
    public class BadShoppingCartTest
    {
        [Test]
        public void GivenShoppingCart_WhenApplyingDiscountToAll_DiscountIsAppliedToAll()
        {
            var products = new List<Bad.IProduct>
            {
                new Bad.Product { Price = 9m, Discount = 0m },
                new Bad.ProductWithNoDiscount { Price = 10m }
            };
            var shoppingCart = new Bad.ShoppingCart();
            var specialDiscount = 0.1m;

            shoppingCart.ApplySpecialDiscountToAllProducts(products, specialDiscount);

            Assert.IsTrue(products.TrueForAll(p => p.Discount == specialDiscount));
        }
    }

    [TestFixture]
    public class GoodShoppingCartTest
    {
        [Test]
        public void GivenShoppingCart_WhenCalculatingTotal_ReturnsCorrectPrice()
        {
            var products = new List<Good.IItemsWithDiscount>
            {
                //new Good.Product { Price = 9m },
                new Good.ProductWithDiscount { Price = 10m },
                new Good.ProductWithDiscount { Price = 20m },
            };
            var shoppingCart = new Good.ShoppingCart();
            var specialDiscount = 0.1m;

            shoppingCart.ApplySpecialDiscountToAllProducts(products, specialDiscount);

            Assert.IsTrue(products.TrueForAll(p => p.Discount == specialDiscount));
        }
    }
}
