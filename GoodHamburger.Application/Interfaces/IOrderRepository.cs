using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.Interfaces;

public interface IOrderRepository
{
    Task CreateAsync(Order order);
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}
