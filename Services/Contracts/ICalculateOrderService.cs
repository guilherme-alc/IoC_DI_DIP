using DependencyStore.Models;

namespace DependencyStore.Services.Interfaces
{
    public interface ICalculateOrderService
    {
        Task<decimal> CalculateTotalProducts(List<Product> products);
        Task<decimal> ApplyDiscount(string promoCode);
    }
}
