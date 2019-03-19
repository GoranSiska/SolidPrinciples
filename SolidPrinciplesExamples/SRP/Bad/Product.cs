using SolidPrinciplesExamples.Misc;

namespace SolidPrinciplesExamples.SRP.Bad
{
    //class responsible for holding product data and storing products
    public class Product
    {
        public decimal Price { get; set; }
        public string Description { get; set; }

        public void Save()
        {
            //code responsible for storing entity
            using (var db = new Database<Product>())
            {
                db.Store(this);
            }
        }
    }
}
