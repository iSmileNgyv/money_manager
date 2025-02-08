using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;

public class GetAllTransactionQueryRequest: IRequest<List<GetAllTransactionQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 50;
}