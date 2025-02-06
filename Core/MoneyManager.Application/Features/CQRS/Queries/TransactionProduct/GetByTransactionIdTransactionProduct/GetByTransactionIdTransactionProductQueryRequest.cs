using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetByTransactionIdTransactionProduct;

public class GetByTransactionIdTransactionProductQueryRequest: IRequest<List<GetByTransactionIdTransactionProductQueryResponse>>
{
    public Guid TransactionId { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}