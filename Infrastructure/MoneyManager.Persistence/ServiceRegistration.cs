using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Repositories.Cashback;
using MoneyManager.Application.Repositories.Category;
using MoneyManager.Application.Repositories.Media;
using MoneyManager.Application.Repositories.PaymentMethod;
using MoneyManager.Application.Repositories.Product;
using MoneyManager.Application.Repositories.Stock;
using MoneyManager.Application.Repositories.Transaction;
using MoneyManager.Application.Repositories.TransactionProduct;
using MoneyManager.Application.Services.Auth;
using MoneyManager.Application.Services.Auth.Types;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Application.Services.Log;
using MoneyManager.Domain.Entities.Identity;
using MoneyManager.Persistence.Contexts;
using MoneyManager.Persistence.Interceptors;
using MoneyManager.Persistence.Repositories.Cashback;
using MoneyManager.Persistence.Repositories.Category;
using MoneyManager.Persistence.Repositories.Media;
using MoneyManager.Persistence.Repositories.PaymentMethod;
using MoneyManager.Persistence.Repositories.Product;
using MoneyManager.Persistence.Repositories.Stock;
using MoneyManager.Persistence.Repositories.Transaction;
using MoneyManager.Persistence.Repositories.TransactionProduct;
using MoneyManager.Persistence.Services.Auth;
using MoneyManager.Persistence.Services.Entities;

namespace MoneyManager.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<MainContext>((serviceProvider, options) =>
        {
            var logService = serviceProvider.GetRequiredService<ILogService>();
            options.UseNpgsql(Configuration.ConnectionString)
                .AddInterceptors(new EfCoreLogInterceptor(logService));
        });
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<MainContext>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IMediaReadRepository, MediaReadRepository>();
        services.AddScoped<IMediaWriteRepository, MediaWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IPaymentMethodReadRepository, PaymentMethodReadRepository>();
        services.AddScoped<IPaymentMethodWriteRepository, PaymentMethodWriteRepository>();
        services.AddScoped<IStockReadRepository, StockReadRepository>();
        services.AddScoped<IStockWriteRepository, StockWriteRepository>();
        services.AddScoped<ICashbackReadRepository, CashbackReadRepository>();
        services.AddScoped<ICashbackWriteRepository, CashbackWriteRepository>();
        services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
        services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();
        services.AddScoped<ITransactionProductReadRepository, TransactionProductReadRepository>();
        services.AddScoped<ITransactionProductWriteRepository, TransactionProductWriteRepository>();


        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPaymentMethodService, PaymentMethodService>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ICashbackService, CashbackService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IInternalAuth, AuthService>();
        services.AddScoped<ITransactionService, TransactionService>();
    }
}