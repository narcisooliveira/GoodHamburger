using GoodHamburger.Application.DTOs;
using GoodHamburger.Application.Interfaces;

namespace GoodHamburger.Application.UseCases;

public class GetOrderById(IOrderRepository repository)
{
    private readonly IOrderRepository _repository = repository;

    public async Task<OrderResponse> Execute(Guid id)
    {
        var order = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Pedido não encontrado");
        
        return new OrderResponse
        {
            Id = order.Id,
            Subtotal = order.Subtotal,
            Discount = order.Discount,
            Total = order.Total
        };
    }
}
