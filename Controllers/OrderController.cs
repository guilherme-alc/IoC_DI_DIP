using DependencyStore.Models;
using DependencyStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, List<Product> products)
    {
        var orderCode = _orderService.CreateOrder(promoCode, products, zipCode);

        return Ok(new
        {
            Message = $"Pedido {orderCode} gerado com sucesso!"
        });
    }
}