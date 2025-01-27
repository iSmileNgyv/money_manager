using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.User.CreateUser;

public class CreateUserCommandRequest: IRequest<CreateUserCommandResponse>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}