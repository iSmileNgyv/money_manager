using CashierWeb.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Repositories.Category;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Persistence.Contexts;
using MoneyManager.Persistence.Repositories.Category;
using MoneyManager.Persistence.Services.Entitites;

namespace MoneyManager.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<MainContext>(options => 
                options.UseNpgsql(Configuration.ConnectionString)
            );

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();



        services.AddScoped<ICategoryService, CategoryService>();
    }
}