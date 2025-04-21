using Shared.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractions
{
    public interface IProductService
    {
        //Get All Products => IEnumerable<ProductResponse>

        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();

        //Get Product
        Task<ProductResponse> GetProductAsync(int id);
        // Get All Brands
        Task<IEnumerable<BrandResponse>> GetBrandsAsync();
        // Get All Types
        Task<IEnumerable<TypeResponse>> GetTypesAsync();
    }
}
