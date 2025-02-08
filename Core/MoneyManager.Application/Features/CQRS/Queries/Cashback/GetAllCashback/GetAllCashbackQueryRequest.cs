using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Cashback.GetAllCashback;

public class GetAllCashbackQueryRequest: IRequest<List<GetAllCashbackQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 50;
}