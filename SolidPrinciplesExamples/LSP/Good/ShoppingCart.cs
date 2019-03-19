using System.Collections.Generic;

namespace SolidPrinciplesExamples.LSP.Good
{
    //class responsible for holding product data
    public class Product
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual decimal SellPrice
        {
            get
            {
                return Price;
            }
        }
    }

    //class responsible for holding product with discount data
    public class ProductWithDiscount : Product
    {
        public virtual decimal Discount { get; set; }
        public override decimal SellPrice
        {
            get
            {
                return Price * Discount;
            }
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
                total += product.SellPrice;
            }
            return total;
        }

        public void ApplySpecialDiscountToAllProducts(List<ProductWithDiscount> products, decimal specialDiscount)
        {
            foreach (var product in products)
            {
                product.Discount = specialDiscount;
            }
        }
    }
}
