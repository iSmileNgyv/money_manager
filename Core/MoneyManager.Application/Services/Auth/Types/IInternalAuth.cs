using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Services.Auth.Types;

public interface IInternalAuth
{
    Task<TokenResponse> LoginAsync(string email, string password, int accessTokenLifeTime);
    Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken);
}