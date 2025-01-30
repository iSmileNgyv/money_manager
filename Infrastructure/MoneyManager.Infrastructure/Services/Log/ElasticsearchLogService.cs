using Microsoft.Extensions.Logging;
using MoneyManager.Application.Services.Log;

namespace MoneyManager.Infrastructure.Services.Log;

public class ElasticsearchLogService(
    ILogger<ElasticsearchLogService> logger
    ) : ILogService
{
    public void LogInformation(string message)
    {
        logger.LogInformation(message);
    }

    public void LogInformation(string message, object additionalData)
    {
        logger.LogInformation("{Message} | Additional Data: {@AdditionalData}", message, additionalData);
    }

    public void LogError(string message, Exception? exception)
    {
        logger.LogError(exception, message);
    }

    public void LogError(string message, object additionalData, Exception? exception)
    {
        logger.LogError(exception, "{Message} | Additional Data: {@AdditionalData}", message, additionalData);
    }
}