namespace MoneyManager.Application.Services.Log;

public interface ILogService
{
    void LogInformation(string message);
    void LogInformation(string message, object additionalData);
    void LogError(string message, Exception? exception = null);
    void LogError(string message, object additionalData, Exception? exception);
}