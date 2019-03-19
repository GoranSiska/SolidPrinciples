using System;

namespace SolidPrinciplesExamples.DIP.Bad
{
    //interface for classes holding product data
    public interface IProduct
    {
        decimal Price { get; set; }
        string Description { get; set; }
    }

    //interface for shopping cart
    public interface IShoppingCart
    {
        void AddProduct(IProduct product);
    }

    //class responsible for storing and retireving shopping carts
    public class ShoppingCartRepository
    {
        public IShoppingCart GetShoppingCartByUserId(int userId)
        {
            //code for retrieving shopping cat by id
            throw new Exception("Need access to database!");

            return default(IShoppingCart);
        }

        public void StoreOrUpdateShoppingCart(IShoppingCart shoppingCart)
        {
            //code for storing or updating shopping cart
            throw new Exception("Need access to database!");
        }
    }

    public class ProductControler
    {
        public void AddProductToCart(IProduct product, int userId)
        {
            var shoppingCartRespository = new ShoppingCartRepository();
            var shoppingCart = shoppingCartRespository.GetShoppingCartByUserId(userId);
            shoppingCart.AddProduct(product);
            shoppingCartRespository.StoreOrUpdateShoppingCart(shoppingCart);
        }
    }
}
