using System;
using System.Collections.Generic;

namespace SolidPrinciplesExamples.DIP.Good
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
        List<IProduct> Products { get; set; }
        void AddProduct(IProduct product);
    }

    //shopping cart
    public class ShoppingCart : Good.IShoppingCart
    {
        public ShoppingCart()
        {
            Products = new List<IProduct>();
        }

        public List<IProduct> Products { get; set; }
        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }
    }

    //interface for shopping cart repository
    public interface IShoppingCartRepository
    {
        IShoppingCart GetShoppingCartByUserId(int userId);
        void StoreOrUpdateShoppingCart(IShoppingCart shoppingCart);
    }

    //class responsible for storing and retireving shopping carts
    public class ShoppingCartRepository : IShoppingCartRepository
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
        private IShoppingCartRepository _shoppingCartRepository;

        public ProductControler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void AddProductToCart(IProduct product, int userId)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartByUserId(userId);
            shoppingCart.AddProduct(product);
            _shoppingCartRepository.StoreOrUpdateShoppingCart(shoppingCart);
    }
    }
}
