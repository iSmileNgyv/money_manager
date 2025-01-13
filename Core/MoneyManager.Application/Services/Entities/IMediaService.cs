using MoneyManager.Application.Features.CQRS.Commands.Media.CreateMedia;
using MoneyManager.Application.Features.CQRS.Commands.Media.RemoveMedia;
using MoneyManager.Application.Features.CQRS.Queries.Media.GetAllMedia;

namespace MoneyManager.Application.Services.Entities;

public interface IMediaService
{
    Task<List<CreateMediaCommandResponse>> CreateMediaAsync(CreateMediaCommandRequest request, CancellationToken ct = default);
    Task<List<GetAllMediaQueryResponse>> GetAllMediaAsync(GetAllMediaQueryRequest request, CancellationToken cancellationToken);
    Task<RemoveMediaCommandResponse> RemoveMediaAsync(RemoveMediaCommandRequest request, CancellationToken cancellationToken);
}