namespace Lecture_5_MVC.Models
{
    public class EcomSampleSite
    {
        public class ProductRepository
        {
            private readonly EcomContext ecomContext;
            public ProductRepository (EcomContext ecomContext)
            {
                this.ecomContext = ecomContext;
            }
            public Product AddProduct(Product product)
            {
                ecomContext.Products.Add(product);
                ecomContext.SaveChanges();
                return product;
            } 
        }
    }
}
