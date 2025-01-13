using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Media.RemoveMedia;

public class RemoveMediaCommandRequest : IRequest<RemoveMediaCommandResponse>
{
    public Guid Id { get; set; }
}