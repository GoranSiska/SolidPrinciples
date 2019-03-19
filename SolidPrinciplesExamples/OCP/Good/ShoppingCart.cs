using System.Collections.Generic;

namespace SolidPrinciplesExamples.OCP.Good
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

    //class responsible for holding discounted product data
    public class ProductWithDiscount : Product
    {
        public decimal Discount { get; set; }
        public override decimal SellPrice
        {
            get
            {
                return Price * Discount;
            }
        }
    }

    //class responsible for holding surcharged product data
    public class ProductWithSurcharge : Product
    {
        public decimal Surcharge { get; set; }
        public override decimal SellPrice
        {
            get
            {
                return Price + Surcharge;
            }
        }
    }

    //class responsible for calculating shopping cart total
    public class ShoppingCart
    {
        public decimal CalculateTotal(List<Product> products)
        {
            var total = 0m;
            //does not need to be changed for new products
            foreach (var product in products)
            {
                total += product.SellPrice;
            }
            return total;
        }
    }
}
