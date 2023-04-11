using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P326FirstApi.Models;

namespace P326FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new()
        {

            new(){Id= 1, Name="Product1",SalePrice=570},
             new(){Id= 2, Name="Product2",SalePrice=530},
              new(){Id= 3, Name="Product3",SalePrice=520},
               new(){Id= 4, Name="Product4",SalePrice=510},

        };




        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, products);

            //return Ok(new {Code=1001,products});
        }
        [Route("{id}")]
        [HttpGet]

        public IActionResult GetOne(int id)
        { 
       Product product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(product); 
        }

        [HttpPost]

        public IActionResult AddProduct(Product product) 
        { 
        products.Add(product);
            return StatusCode(StatusCodes.Status201Created, product);
        }

    }
}


