using DependencyStore.Models;

namespace DependencyStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product?> GetProductById(string id);
    }
}
