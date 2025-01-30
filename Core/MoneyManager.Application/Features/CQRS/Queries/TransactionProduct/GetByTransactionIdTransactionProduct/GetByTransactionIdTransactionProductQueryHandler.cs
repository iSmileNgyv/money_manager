using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetByTransactionIdTransactionProduct;

public class GetByTransactionIdTransactionProductQueryHandler(
    ITransactionProductService service
    ): IRequestHandler<GetByTransactionIdTransactionProductQueryRequest, List<GetByTransactionIdTransactionProductQueryResponse>>
{
    public async Task<List<GetByTransactionIdTransactionProductQueryResponse>> Handle(GetByTransactionIdTransactionProductQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetByTransactionIdTransactionProductAsync(request, cancellationToken);
    }
}