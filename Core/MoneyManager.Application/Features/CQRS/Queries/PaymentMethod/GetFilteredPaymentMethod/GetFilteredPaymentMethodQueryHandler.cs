using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;

public class GetFilteredPaymentMethodQueryHandler(
    IPaymentMethodService service
    ): IRequestHandler<GetFilteredPaymentMethodQueryRequest, List<GetFilteredPaymentMethodQueryResponse>>
{
    public async Task<List<GetFilteredPaymentMethodQueryResponse>> Handle(GetFilteredPaymentMethodQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetFilteredPaymentMethodsAsync(request, cancellationToken);
    }
}