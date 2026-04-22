using GoodHamburger.Application.Interfaces;
using GoodHamburger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace GoodHamburger.Infrastructure;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;
    private IDbContextTransaction? _transaction;

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction!.RollbackAsync();
    }
}