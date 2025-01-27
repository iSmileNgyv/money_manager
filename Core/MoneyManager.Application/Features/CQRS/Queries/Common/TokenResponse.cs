namespace MoneyManager.Application.Features.CQRS.Queries.Common;

public class TokenResponse
{
    public required string AccessToken { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? RefreshToken { get; set; }
}