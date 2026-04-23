using GoodHamburger.Application.Interfaces;
using GoodHamburger.Infrastructure.Contexts;
using GoodHamburger.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburger.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(connectionString));

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
