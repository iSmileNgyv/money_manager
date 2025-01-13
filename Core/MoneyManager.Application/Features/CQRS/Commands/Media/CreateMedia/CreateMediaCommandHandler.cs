using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Media.CreateMedia;

public class CreateMediaCommandHandler(
    IMediaService service
    ) : IRequestHandler<CreateMediaCommandRequest, List<CreateMediaCommandResponse>>
{
    public async Task<List<CreateMediaCommandResponse>> Handle(CreateMediaCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateMediaAsync(request, cancellationToken);
    }
}