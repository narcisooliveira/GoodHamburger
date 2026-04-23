using GoodHamburger.Domain.Helpers;

namespace GoodHamburger.Application.UseCases;

public class GetMenuUseCase
{
    public async Task<object> Execute()
        => await Task.FromResult(MenuHelper.GetMenu());
}
