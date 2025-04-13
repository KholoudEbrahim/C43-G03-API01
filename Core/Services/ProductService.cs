using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class ProductService(IUnitOfWork unitOfWork , IMapper mapper) 
        : IProductService
    {
        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
           var product = await unitOfWork.GetRepository<Product, int>().GetAllAsync();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(product);
        }

        public async Task<ProductResponse> GetProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            return mapper.Map<Product ,ProductResponse>(product);
        }
   

        //public async Task<IEnumerable<BrandResponse>> GetBrandAsync()
        //{
        //    var repo = unitOfWork.GetRepository<ProductBrand, int>();
        //    var brands = await repo.GetAllAsync();
        //    return mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandResponse>>(brands);
        //}

        public async Task<IEnumerable<TypeResponse>> GetTypesAsync()
        {
            // unit of work => IEnumerable<ProductTypes>
            var repo = unitOfWork.GetRepository<ProductType, int>();
            var types = await repo.GetAllAsync();
            return mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeResponse>>(types);
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandAsync()
        {
            var repo = unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetAllAsync();
            return mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandResponse>>(brands);
        }
    }
}
