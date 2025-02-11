namespace MoneyManager.Application.Services.Media.DTO;

public class ReceiveMessageDto
{
    public long MessageId { get; set; }
    public TelegramChat Chat { get; set; }
    public TelegramSender From { get; set; }
    public required string Text { get; set; }
}