using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;

public class GetFilteredCashbackQueryHandler(
    ICashbackService service
    ): IRequestHandler<GetFilteredCashbackQueryRequest, List<GetFilteredCashbackQueryResponse>>
{
    public async Task<List<GetFilteredCashbackQueryResponse>> Handle(GetFilteredCashbackQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.FilterCashbackAsync(request, cancellationToken);
    }
}