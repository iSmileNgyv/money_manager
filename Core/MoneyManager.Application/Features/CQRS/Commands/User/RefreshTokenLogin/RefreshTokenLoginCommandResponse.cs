using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Commands.User.RefreshTokenLogin;

public class RefreshTokenLoginCommandResponse
{
    public TokenResponse? Token { get; set; }
}