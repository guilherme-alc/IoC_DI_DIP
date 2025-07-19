using DependencyStore.Models;
using DependencyStore.Repositories;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services.Interfaces;

namespace DependencyStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Product?> GetProductById(string id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
