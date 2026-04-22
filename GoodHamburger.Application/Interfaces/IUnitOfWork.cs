namespace GoodHamburger.Application.Interfaces;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task<int> CommitAsync();
    Task RollbackAsync();
}
