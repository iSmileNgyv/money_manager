namespace MoneyManager.Application.Services.Media.DTO;

public class TelegramSender
{
    public long Id { get; set; }
    public bool IsBot { get; set; }
    public required string FirstName { get; set; }
    public required string Username { get; set; }
    
}