using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.User.Loginuser;

public class LoginUserCommandRequest: IRequest<LoginUserCommandResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}