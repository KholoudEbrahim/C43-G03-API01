using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServicesAbstractions;
using Shared.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        //Get All Products => IEnumerable<ProductResponse>
        //Get Product
        // Get All Brands
        // Get All Types

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductResponse>>>> GetAllProducts() // Get BaseUrl/Products
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync();

            return Ok(value: products);

        }



        [HttpGet(template: "{id}")]

        public async Task<ActionResult<ProductResponse>> GetProduct(int id) // Get BaseUrl/Products/{id}

        {

            var product = await serviceManager.ProductService.GetProductAsync(id);
            return Ok(value: product);

        }

        [HttpGet(template: "brands")]

        public async Task<ActionResult<BrandResponse>> GetBrands() // Get BaseUrl/api/Products/brands {
        {
            var brands = await serviceManager.ProductService.GetBrandsAsync();
            return Ok(value: brands);
        }
    }
}