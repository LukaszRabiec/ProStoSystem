using System.Collections.Generic;

namespace ProStoSystem.Logic.Services.Concrete
{
    using System.Linq;
    using Abstract;
    using Database.Entities;
    using Repositories.Abstract;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
