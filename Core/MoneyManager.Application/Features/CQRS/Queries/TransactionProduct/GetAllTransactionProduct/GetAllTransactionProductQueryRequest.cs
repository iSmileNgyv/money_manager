using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;

public class GetAllTransactionProductQueryRequest: IRequest<List<GetAllTransactionProductQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 50;
}