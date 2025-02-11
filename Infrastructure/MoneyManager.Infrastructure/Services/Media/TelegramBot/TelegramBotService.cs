using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Services.Log;
using MoneyManager.Application.Services.Media.TelegramBot;
using Serilog;

namespace MoneyManager.Infrastructure.Services.Media.TelegramBot;

public class TelegramBotService(
    ILogService logService,
    HttpClient httpClient,
    IConfiguration configuration
    ): ITelegramBotService
{
    public async Task<bool> SendMessageAsync(long chatId, string message)
    {
        var payload = new
        {
            chat_id = chatId,
            text = message
        };
        string jsonPayload = JsonSerializer.Serialize(payload);
        logService.LogInformation($"chatId: {chatId}, message: {message}");
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await httpClient.PostAsync(configuration["Media:TelegramBot:Url"], content);
            if (response.IsSuccessStatusCode)
            {
                logService.LogInformation($"Message sent successfully to {chatId}: {message}");
                return true;
            }

            logService.LogError($"Failed to send message: {response.ReasonPhrase}");
            return false;
        }
        catch (HttpRequestException ex)
        {
            logService.LogError($"Error while sending message: {ex.Message}");
            return false;
        }
    }
}