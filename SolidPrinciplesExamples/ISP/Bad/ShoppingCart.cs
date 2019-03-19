using System;
using System.Collections.Generic;

namespace SolidPrinciplesExamples.ISP.Bad
{
    //interface for classes holding product data
    public interface IProduct
    {
        decimal Price { get; set; }
        string Description { get; set; }
        decimal Discount { get; set; }
    }

    //class holding product data
    public class Product : IProduct
    {
        public decimal Price{ get; set; }
        public string Description{ get; set; }
        public decimal Discount { get; set; }
    }

    //class responsible for holding product with no discount data
    public class ProductWithNoDiscount : IProduct
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Discount
        {
            get { return 1; }
            set { throw new Exception("Can't discount this!"); }
        }
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

        public void ApplySpecialDiscountToAllProducts(List<IProduct> products, decimal specialDiscount)
        {
            foreach (var product in products)
            {
                product.Discount = specialDiscount;
            }
        }
    }
}
