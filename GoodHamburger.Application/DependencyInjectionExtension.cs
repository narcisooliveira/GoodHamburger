using GoodHamburger.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburger.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderUseCase>();
        services.AddScoped<GetOrdersUseCase>();
        services.AddScoped<GetOrderByIdUseCase>();
        services.AddScoped<DeleteOrderByIdUseCase>();
        services.AddScoped<GetMenuUseCase>();
        return services;
    }
}
