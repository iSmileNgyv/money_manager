using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;

public class GetFilteredTransactionQueryHandler(
    ITransactionService service
    ): IRequestHandler<GetFilteredTransactionQueryRequest, List<GetFilteredTransactionQueryResponse>>
{
    public async Task<List<GetFilteredTransactionQueryResponse>> Handle(GetFilteredTransactionQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetFilteredTransactionAsync(request, cancellationToken);
    }
}