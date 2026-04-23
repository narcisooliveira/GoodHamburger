using GoodHamburger.Application.DTOs;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;
using GoodHamburger.Domain.Helpers;

namespace GoodHamburger.Application.UseCases;

public class CreateOrderUseCase(
    IOrderRepository repository,
    IUnitOfWork unitOfWork)
{
    private readonly IOrderRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<OrderResponse> Execute(CreateOrderRequest request)
    {
        if (request.Items.Count == 0)
            throw new Exception("Pedido vazio");

        var order = new Order();

        foreach (var code in request.Items)
        {
            var (type, price) = MenuHelper.GetItem(code);

            order.AddItem(new OrderItem(type, code, price));
        }

        order.CalculateTotals();

        await _repository.CreateAsync(order);

        var result = await _unitOfWork.CommitAsync();

        if (result == 0)
            throw new Exception("Erro ao criar pedido");

        return new OrderResponse
        {
            Id = order.Id,
            Subtotal = order.Subtotal,
            Discount = order.Discount,
            Total = order.Total
        };
    }
}

public class CreateOrderRequest
{
    public List<MenuCode> Items { get; set; } = [];
}