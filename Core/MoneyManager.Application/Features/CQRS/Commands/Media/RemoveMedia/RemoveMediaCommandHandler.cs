using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Media.RemoveMedia;

public class RemoveMediaCommandHandler(
    IMediaService service
    ) : IRequestHandler<RemoveMediaCommandRequest, RemoveMediaCommandResponse>
{
    public async Task<RemoveMediaCommandResponse> Handle(RemoveMediaCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemoveMediaAsync(request, cancellationToken);
    }
}