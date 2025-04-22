using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IMapper mapper, IUnitOfWork unitOfWork) : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyproductService =
            new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
        public IProductService ProductService => _lazyproductService.Value;
        private readonly Lazy<IBasketService> _lazyBasketService;
        public IBasketService BasketService => _lazyBasketService.Value;
    }
}
