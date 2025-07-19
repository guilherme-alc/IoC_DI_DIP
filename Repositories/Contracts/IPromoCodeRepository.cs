using DependencyStore.Models;

namespace DependencyStore.Repositories.Interfaces
{
    public interface IPromoCodeRepository
    {
        Task<PromoCode?> GetPromoByCode(string promoCode);
    }
}
