using NUnit.Framework;
using SolidPrinciplesExamples.DIP.Good;

namespace SolidPrinciplesExamples.DIP.Test
{
    public class BadTestProduct : Bad.IProduct
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class GoodTestProduct : Good.IProduct
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    [TestFixture]
    public class BadProductControlerTest
    {
        [Test]
        public void GivenExistingShoppingCart_WhenAddingNewProduct_NewProductIsAdded()
        {
            var productControler = new Bad.ProductControler();
            var product = new BadTestProduct();
            var userId = 1;

            productControler.AddProductToCart(product, userId);

            //???
        }
    }

    public class TestRepository : Good.IShoppingCartRepository
    {
        public IShoppingCart GetShoppingCartByUserId(int userId)
        {
            return new ShoppingCart();       
        }

        public void StoreOrUpdateShoppingCart(IShoppingCart shoppingCart)
        {
            LastStoredShoppingCart = shoppingCart;
        }

        public IShoppingCart LastStoredShoppingCart { get; set; }
    }

    [TestFixture]
    public class GoodProductControlerTest
    {
        [Test]
        public void GivenExistingShoppingCart_WhenAddingNewProduct_NewProductIsAdded()
        {
            var testShoppingCartRepository = new TestRepository();
            var productControler = new Good.ProductControler(testShoppingCartRepository);
            var product = new GoodTestProduct();
            var userId = 1;

            productControler.AddProductToCart(product, userId);

            Assert.AreEqual(testShoppingCartRepository.LastStoredShoppingCart.Products[0], product);
        }
    }
}
