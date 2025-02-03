using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;

public class GetFilteredTransactionQueryRequest: IRequest<List<GetFilteredTransactionQueryResponse>>
{
    public Guid? CategoryId { get; set; }
    public Guid? StockId { get; set; }
}