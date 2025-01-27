using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Services.Auth;
using MoneyManager.Application.Services.Storage;
using MoneyManager.Infrastructure.Services.Storage;
using TokenHandler = MoneyManager.Infrastructure.Services.Auth.TokenHandler;

namespace MoneyManager.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
    }
    
    public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
    }
}