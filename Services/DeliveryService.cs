using DependencyStore.Services.Interfaces;
using RestSharp;

namespace DependencyStore.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly HttpClient _httpClient;
        public DeliveryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<decimal> CalculateDeliveryFee(string zipCode)
        {
             var response = await _httpClient.PostAsJsonAsync("https://consultafrete.io/cep/", new { zipCode });

            if (response.IsSuccessStatusCode)
            {
                decimal deliveryFee = await response.Content.ReadFromJsonAsync<decimal>();
                if (deliveryFee < 5)
                    deliveryFee = 5;
                return deliveryFee;
            }

            return 0;
        }
    }
}
