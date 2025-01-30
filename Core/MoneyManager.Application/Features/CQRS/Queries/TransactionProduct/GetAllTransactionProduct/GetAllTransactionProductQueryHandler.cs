using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;

public class GetAllTransactionProductQueryHandler(
    ITransactionProductService service
    ): IRequestHandler<GetAllTransactionProductQueryRequest, List<GetAllTransactionProductQueryResponse>>
{
    public async Task<List<GetAllTransactionProductQueryResponse>> Handle(GetAllTransactionProductQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllTransactionProductAsync(request, cancellationToken);
    }
}