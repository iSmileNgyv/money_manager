using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.User.RefreshTokenLogin;

public class RefreshTokenLoginCommandRequest: IRequest<RefreshTokenLoginCommandResponse>
{
    public string? RefreshToken { get; set; }
}