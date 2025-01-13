using CashierWeb.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Repositories.Category;
using MoneyManager.Application.Repositories.Media;
using MoneyManager.Application.Repositories.Product;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Persistence.Contexts;
using MoneyManager.Persistence.Repositories.Category;
using MoneyManager.Persistence.Repositories.Media;
using MoneyManager.Persistence.Repositories.Product;
using MoneyManager.Persistence.Services.Entities;

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
        services.AddScoped<IMediaReadRepository, MediaReadRepository>();
        services.AddScoped<IMediaWriteRepository, MediaWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();



        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<IProductService, ProductService>();
    }
}