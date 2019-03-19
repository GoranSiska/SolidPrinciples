using System.Collections.Generic;

namespace SolidPrinciplesExamples.OCP.Bad
{
    //class responsible for holding product data
    public class Product
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    //class responsible for holding discounted product data
    public class ProductWithDiscount : Product
    {
        public decimal Discount { get; set; }
    }

    //class responsible for calculating shopping cart total
    public class ShoppingCart
    {
        public decimal CalculateTotal(List<Product> products)
        {
            var total = 0m;
            foreach(var product in products)
            {
                //inspecting type of product
                if (product is ProductWithDiscount)
                {
                    var productWithDiscount = product as ProductWithDiscount;
                    var discountedPrice = productWithDiscount.Price * productWithDiscount.Discount;
                    total += discountedPrice;
                }
                //n* if else if some other kind of products
                else
                {
                    total += product.Price;
                }
            }
            return total;
        }
    }
}
