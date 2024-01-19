using Microsoft.EntityFrameworkCore;

namespace Lecture_5_MVC.Models
{
    public class EcomContext: DbContext
    {
        public EcomContext(DbContextOptions<EcomContext> options):base(options) 
        {
            
        } 
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGallery> ProductGallerys { get; set; }

    }
}
