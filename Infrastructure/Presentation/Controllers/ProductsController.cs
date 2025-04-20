using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServicesAbstractions;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<PaginatedResponse<ProductResponse>>>
            GetAllProducts([FromQuery] ProductQueryParameters queryParameters) // Get BaseUrl/Products
        {
            throw new Exception("Test");
            var products = await serviceManager.ProductService.GetAllProductsAsync(queryParameters);

            return Ok(value: products);

        }



        [HttpGet( "{id}")]

        public async Task<ActionResult<ProductResponse>> GetProduct(int id) // Get BaseUrl/Products/{id}

        {

            var product = await serviceManager.ProductService.GetProductAsync(id);
            return Ok( product);

        }

        [HttpGet( "brands")]

        public async Task<ActionResult<BrandResponse>> GetBrands() // Get BaseUrl/api/Products/brands 
        {
            var brands = await serviceManager.ProductService.GetBrandsAsync();
            return Ok( brands);
        }

        [HttpGet("types")]

        public async Task<ActionResult<TypeResponse>> GetTypes() // Get BaseUrl/api/Products/types 
        {
            var types = await serviceManager.ProductService.GetTypesAsync();
            return Ok(types);
        }
    }
}
        //Get All Products => IEnumerable<ProductResponse>
        //Get Product
        // Get All Brands
        // Get All Types
