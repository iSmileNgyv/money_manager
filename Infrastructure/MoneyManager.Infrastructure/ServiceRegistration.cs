using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Services.Storage;
using MoneyManager.Infrastructure.Services.Storage;

namespace MoneyManager.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
    }
    
    public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
    }
}