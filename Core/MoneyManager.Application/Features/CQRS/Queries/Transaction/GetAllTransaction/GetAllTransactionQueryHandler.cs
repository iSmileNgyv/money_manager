using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;

public class GetAllTransactionQueryHandler(
    ITransactionService service
    ): IRequestHandler<GetAllTransactionQueryRequest, List<GetAllTransactionQueryResponse>>
{
    public async Task<List<GetAllTransactionQueryResponse>> Handle(GetAllTransactionQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllTransactionAsync(request, cancellationToken);
    }
}