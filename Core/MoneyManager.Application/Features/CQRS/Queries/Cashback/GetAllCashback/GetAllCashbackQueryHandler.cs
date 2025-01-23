using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Cashback.GetAllCashback;

public class GetAllCashbackQueryHandler(
    ICashbackService service
    ): IRequestHandler<GetAllCashbackQueryRequest, List<GetAllCashbackQueryResponse>>
{
    public async Task<List<GetAllCashbackQueryResponse>> Handle(GetAllCashbackQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllCashbackAsync(request, cancellationToken);
    }
}