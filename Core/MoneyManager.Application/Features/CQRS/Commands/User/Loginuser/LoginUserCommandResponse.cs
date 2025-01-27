using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Commands.User.Loginuser;

public class LoginUserCommandResponse
{
    public TokenResponse? Token { get; set; }
}