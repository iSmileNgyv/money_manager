using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Services.Log;
using MoneyManager.Application.Services.Media.DTO;
using MoneyManager.Application.Services.Media.TelegramBot;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class TelegramBotController(
    ITelegramBotService telegramBotService,
    ILogService logService
    ) : Controller
{
    [HttpPost("webhook")]
    public async Task<IActionResult> ReceiveMessage([FromBody] TelegramUpdate update)
    {
        logService.LogInformation("webhook received", update);
        if (update?.Message == null)
        {
            return BadRequest("Invalid request");
        }
        long chatId = update.Message.Chat.Id;
        string userMessage = update.Message.Text;
        bool isBot = update.Message.From.IsBot;
        await telegramBotService.SendMessageAsync(chatId, userMessage);
        return Ok();
    }
}