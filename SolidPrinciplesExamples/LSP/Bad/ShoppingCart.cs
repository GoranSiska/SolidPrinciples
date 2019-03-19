using System;
using System.Collections.Generic;

namespace SolidPrinciplesExamples.LSP.Bad
{
    //class responsible for holding product data
    public class Product
    {
        public decimal Price{ get; set; }
        public string Description{ get; set; }
        public virtual decimal Discount { get; set; }
    }

    //class responsible for holding product no discount data
    public class ProductWithNoDiscount : Product
    {
        public override decimal Discount
        {
            get { return 1; }
            set { /*do nothing*/ }
        }
    }

    //class responsible for shopping cart operations
    public class ShoppingCart
    {
        public decimal CalculateTotal(List<Product> products)
        {
            var total = 0m;
            foreach (var product in products)
            {
                total += product.Price * product.Discount;
            }
            return total;
        }

        public void ApplySpecialDiscountToAllProducts(List<Product> products, decimal specialDiscount)
        {
            foreach (var product in products)
            {
                product.Discount = specialDiscount;
            }
        }
    }
}
