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
        public ProductWithBrandAndTypeSpecifications(ProductQueryParameters parameters, bool includeCriteria = true)
            : base(criteria: includeCriteria ? CreateCriteria(parameters) : null)
        {
            // Add Includes
            AddInclude(include: p => p.ProductBrand);
            AddInclude(include: p => p.ProductType);
            ApplySorting(parameters.options);
            ApplyPagination(parameters.PageSize, parameters.PageIndex);


            // Apply Sorting if needed
            //if (includeCriteria)
            //{
            //    ApplySorting(parameters.options);
            //}
        }

        private static System.Linq.Expressions.Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
        {
            return product =>
                (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
                (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value) &&
                (string.IsNullOrWhiteSpace(parameters.Search)  ||
                product.Name.ToLower().Contains(parameters.Search.ToLower()));
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
                    AddOrderBy(p => p.Price);
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