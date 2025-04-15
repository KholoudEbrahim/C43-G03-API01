using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Products
{
    public record ProductResponse
    {
        public int Id { get; init; }
        public string Name { get; init; } 
        public string Description { get; init; }
        public string PictureUrl { get; init; } 
        public decimal Price { get; init; }
        public string BrandName { get; init; }
        public string TypeName { get; init; }




    }
}
