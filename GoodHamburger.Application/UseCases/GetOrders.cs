using GoodHamburger.Application.DTOs;
using GoodHamburger.Application.Interfaces;

namespace GoodHamburger.Application.UseCases;

public class GetOrders(IOrderRepository repository)
{
    private readonly IOrderRepository _repository = repository;
    public async Task<List<OrderResponse>> Execute()
    {
        var orders = await _repository.GetAllAsync();
        return orders.Select(order => new OrderResponse
        {
            Id = order.Id,
            Subtotal = order.Subtotal,
            Discount = order.Discount,
            Total = order.Total
        }).ToList();
    }
}
