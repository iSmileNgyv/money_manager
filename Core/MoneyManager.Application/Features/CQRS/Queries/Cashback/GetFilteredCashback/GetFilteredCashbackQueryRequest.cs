using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;

public class GetFilteredCashbackQueryRequest: IRequest<List<GetFilteredCashbackQueryResponse>>
{
    public Guid? CategoryId { get; set; }
    public Guid? PaymentMethodId { get; set; }
    public Guid? StockId { get; set; }
}