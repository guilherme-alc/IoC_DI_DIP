using DependencyStore.Models;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services.Interfaces;

namespace DependencyStore.Services
{
    public class CalculateOrderService : ICalculateOrderService
    {
        private readonly IProductService _productService;
        private readonly IPromoCodeRepository _promoCodeRepository;

        public CalculateOrderService(IProductService productService, IPromoCodeRepository promoCodeRepository)
        {
            _productService = productService;
            _promoCodeRepository = promoCodeRepository;
        }

        public async Task<decimal> CalculateTotalProducts(List<Product> products)
        {
            var tasks = products.Select(p => _productService.GetProductById(p.Id.ToString())).ToArray();
            var productsList = await Task.WhenAll(tasks);
            decimal subTotal = productsList.Sum(product => product?.Price ?? 0);
            return subTotal;
        }

        public async Task<decimal> ApplyDiscount(string promoCode)
        {
            decimal discount = 0;

            var promo = await _promoCodeRepository.GetPromoByCode(promoCode);

            if (promo is not null)
            {
                if (promo.ExpireDate > DateTime.Now)
                    discount = promo.Value;
            }
            return discount;
        }
    }
}
