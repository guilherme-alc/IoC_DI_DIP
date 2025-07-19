using DependencyStore.Models;
using DependencyStore.Services.Interfaces;

namespace DependencyStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICalculateOrderService _calculateOrderService;
        private readonly IDeliveryService _deliveryService;
        public OrderService(ICalculateOrderService calculateOrderService, IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
            _calculateOrderService = calculateOrderService;
        }
        public async Task<string> CreateOrder(string promoCode, List<Product> products, string zipCode)
        {
            var discount = await _calculateOrderService.ApplyDiscount(promoCode);
            var subTotal = await _calculateOrderService.CalculateTotalProducts(products);
            var deliveryFee = await _deliveryService.CalculateDeliveryFee(promoCode);

            var order = new Order(discount, deliveryFee, products);

            return order.Code;
        }
    }
}
