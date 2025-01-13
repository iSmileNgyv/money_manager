using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Media.GetAllMedia;

public class GetAllMediaQueryHandler(
    IMediaService service
    ) : IRequestHandler<GetAllMediaQueryRequest, List<GetAllMediaQueryResponse>>
{
    public async Task<List<GetAllMediaQueryResponse>> Handle(GetAllMediaQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllMediaAsync(request, cancellationToken);
    }
}