namespace MoneyManager.Application.Services.Media.TelegramBot;

public interface ITelegramBotService
{
    Task<bool> SendMessageAsync(long chatId, string message);
}