using MediatR;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Services.Auth;

namespace MoneyManager.Application.Features.CQRS.Commands.User.Loginuser;

public class LoginUserCommandHandler(
    IAuthService authService
    ): IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        TokenResponse token = await authService.LoginAsync(request.Email, request.Password, 30);
        return new()
        {
            Token = token
        };
    }
}