//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;

//namespace E_Commerce.Web.Controllers
//{
//    [Route("api/[controller]")] //baseUrl/api/Products
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        [HttpGet("{id:int}")]
//        public ActionResult<Product> Get(int id) //  Get baseUrl/api/Products/10
//        {
//            return new Product() { Id = id };

//        }

       
//        [HttpGet]
//        public ActionResult<Product> GetAll([FromQuery]int id) //  Get baseUrl/api/Products
//        {     return new Product() { Id = 100 };

//        }
//        [HttpPost]
//        public ActionResult<Product> Add(Product product) //  Post baseUrl/api/Products
//        {
//            return new Product() { Id = 100 };

//        }
//        [HttpPut]
//        public ActionResult<Product> Update(Product product) //  Put baseUrl/api/Products
//        {
//            return new Product() { Id = 100 };

//        }
//        [HttpDelete]
//        public ActionResult<Product> Delete(int id) //  Delete baseUrl/api/Products
//        {
//            return new Product() { Id = 100 };

//        }



//    }

//    public class Product
//    {

//        [Range(1, 2)]
//        public int Id { get; set; }

//        [Required]
//        public string Name { get; set; }
//    }
//}
