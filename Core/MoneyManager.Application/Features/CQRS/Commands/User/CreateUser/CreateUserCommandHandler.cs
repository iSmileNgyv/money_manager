using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.User.CreateUser;

public class CreateUserCommandHandler(
    IUserService service
    ): IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateUserAsync(request);
    }
}