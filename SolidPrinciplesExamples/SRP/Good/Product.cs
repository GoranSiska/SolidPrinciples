using SolidPrinciplesExamples.Misc;

namespace SolidPrinciplesExamples.SRP.Good
{
    //class responsible for holding product data
    public class Product
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    //class responsible for storing products
    public class ProductRepository
    {
        public void Store(Product product)
        {
            //code responsible for storing entity
            using (var db = new Database<Product>())
            {
                db.Store(product);
            }
        }
    }
}
