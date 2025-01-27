using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethodWithoutPagination;

public class GetAllPaymentMethodWithoutPaginationQueryHandler(
    IPaymentMethodService service
    ): IRequestHandler<GetAllPaymentMethodWithoutPaginationQueryRequest, List<GetAllPaymentMethodWithoutPaginationQueryResponse>>
{
    public async Task<List<GetAllPaymentMethodWithoutPaginationQueryResponse>> Handle(GetAllPaymentMethodWithoutPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllPaymentMethodsWithoutPaginationAsync(request, cancellationToken);
    }
}