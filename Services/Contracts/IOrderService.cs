using DependencyStore.Models;

namespace DependencyStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<string> CreateOrder(string promoCode, List<Product> products, string zipCode);
    }
}
