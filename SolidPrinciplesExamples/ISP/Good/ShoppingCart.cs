using System.Collections.Generic;

namespace SolidPrinciplesExamples.ISP.Good
{
    //interface for classes holding product data
    public interface IProduct
    {
        decimal Price { get; set; }
        string Description { get; set; }
    }

    public interface IItemsWithDiscount
    {
        decimal Discount { get; set; }
    }

    //class responsible for holding product data
    public class Product
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    //class responsible for holding discountable product data
    public class ProductWithDiscount : Product, IItemsWithDiscount
    {
        public virtual decimal Discount { get; set; }
    }

    //class responsible for shopping cart operations
    public class ShoppingCart
    {
        public decimal CalculateTotal(List<IProduct> products)
        {
            var total = 0m;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }

        public void ApplySpecialDiscountToAllProducts(List<IItemsWithDiscount> products, decimal specialDiscount)
        {
            foreach (var product in products)
            {
                product.Discount = specialDiscount;
            }
        }
    }
}
