using Lecture_5_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace Lecture_5_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
    
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel pva)
        {
            List<string> uniqueCFileNames = new List<string>();

            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            if (pva.ProductImage!=null)
            {
                var product = new Product()
                {
                    
                    ProductName = pva.productName,
                    ProductDescription = pva.productDescription,
                    Quantity = pva.quantity,
                    unitprice = pva.unitprice,
                    imagepath = "/Images/" + uniqueCFileNames
                };
                product.imageGallery = new List<ProductGallery>();

                foreach (IFormFile image in pva.ProductImages)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + image.Name;
                    string uniquefilename = Path.Combine(uploadFolder, fileName);
                    image.CopyTo(new FileStream(uniquefilename, FileMode.Create));
                    uniqueCFileNames.Add(uniquefilename);
                }
            }
            return View(pva);
        }
    }
}



//Microsoft.EntityFrameworkCore.Design --
//Microsoft.EntityFrameworkCore.Tools --
//Microsoft.EntityFrameworkCore.SQlServer --

