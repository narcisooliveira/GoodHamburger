using GoodHamburger.Application.Interfaces;

namespace GoodHamburger.Application.UseCases;

public class DeleteOrderById(
    IOrderRepository repository,
    IUnitOfWork unitOfWork)
{
    private readonly IOrderRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> Execute(Guid id)
    {
        await _repository.DeleteAsync(id);

        return await _unitOfWork.CommitAsync();
    }
}
