using Microsoft.Extensions.Configuration;

namespace MoneyManager.Application;

public static class Configuration
{
    public static IConfigurationRoot GetConfiguration()
    {
        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
        return configBuilder.Build();
    }
    public static string? ConnectionString
    {
        get
        {
            var configuration = GetConfiguration();
            return configuration.GetConnectionString("PostgreSQL");
        }
    }
    
}