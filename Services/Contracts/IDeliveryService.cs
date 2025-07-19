namespace DependencyStore.Services.Interfaces
{
    public interface IDeliveryService
    {
        Task<decimal> CalculateDeliveryFee(string zipCode);
    }
}
