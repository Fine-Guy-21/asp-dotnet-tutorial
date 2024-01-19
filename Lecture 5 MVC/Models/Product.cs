namespace Lecture_5_MVC.Models
{
    public class Product
    {
        public  int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity {  get; set; }
        public decimal unitprice { get; set; }
        public string imagepath { get; set; }
        public List<ProductGallery> imageGallery { get; set; }
    }
}
