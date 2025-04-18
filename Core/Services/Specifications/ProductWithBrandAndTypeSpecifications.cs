using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product>
    {
        // Use this CTOR to Create Query to Get Product By Id
        public ProductWithBrandAndTypeSpecifications(int id)
            : base(criteria: product => product.Id == id)
        {
            // Add Includes
            AddInclude(include: p => p.ProductBrand);
            AddInclude(include: p => p.ProductType);
        }

        // Use this CTOR to Create Query to Get All Products
        public ProductWithBrandAndTypeSpecifications()
            : base(criteria: null)
        {
            // Add Includes
            AddInclude(include: p => p.ProductBrand);
            AddInclude(include: p => p.ProductType);
        }

        public ProductWithBrandAndTypeSpecifications(int? brandId, int? typeId, ProductSortingOptions options)
            : base(criteria: CreateCriteria(brandId, typeId))
        {
            // Add Includes
            AddInclude(include: p => p.ProductBrand);
            AddInclude(include: p => p.ProductType);
            ApplySorting(options);
        }

        private static System.Linq.Expressions.Expression<Func<Product, bool>> CreateCriteria(int? brandId, int? typeId)
        {
            return product =>
                (!brandId.HasValue || product.BrandId == brandId.Value) &&
                (!typeId.HasValue || product.TypeId == typeId.Value);
        }

        private void ApplySorting(ProductSortingOptions options)
        {
            switch (options)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(orderByDescending: p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy( p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(orderByDescending: p => p.Price);
                    break;
                default:
                    break;
            }
        }
    }
}