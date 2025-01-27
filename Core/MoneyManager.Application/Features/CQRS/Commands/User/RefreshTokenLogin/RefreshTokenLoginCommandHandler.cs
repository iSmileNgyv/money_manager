using MediatR;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Services.Auth;

namespace MoneyManager.Application.Features.CQRS.Commands.User.RefreshTokenLogin;

public class RefreshTokenLoginCommandHandler(
    IAuthService authService
    ): IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
{
    public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
    {
        if(request.RefreshToken is null)
            throw new ArgumentNullException(nameof(request.RefreshToken));
        TokenResponse token = await authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new()
        {
            Token = token
        };
    }
}