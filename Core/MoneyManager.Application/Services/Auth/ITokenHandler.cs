using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Services.Auth;

public interface ITokenHandler
{
    TokenResponse CreateAccessToken(int second);
    string CreateRefreshToken();
}