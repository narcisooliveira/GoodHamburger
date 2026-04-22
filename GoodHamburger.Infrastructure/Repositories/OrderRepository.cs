using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.Repositories;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    private readonly AppDbContext _context = context;

    public async Task CreateAsync(Order order)
        => await _context.Orders.AddAsync(order);    

    public async Task<List<Order>> GetAllAsync()
        => await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();    

    public async Task<Order?> GetByIdAsync(Guid id)
        => await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

    public async Task DeleteAsync(Guid id)
    {
        var order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);

        if (order is null)
            return;

        _context.Orders.Remove(order);
    }
}
