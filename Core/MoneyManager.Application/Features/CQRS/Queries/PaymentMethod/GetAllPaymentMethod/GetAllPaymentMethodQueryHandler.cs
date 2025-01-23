using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethod;

public class GetAllPaymentMethodQueryHandler(
    IPaymentMethodService service
    ): IRequestHandler<GetAllPaymentMethodQueryRequest, List<GetAllPaymentMethodQueryResponse>>
{
    public async Task<List<GetAllPaymentMethodQueryResponse>> Handle(GetAllPaymentMethodQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllPaymentMethodsAsync(request, cancellationToken);
    }
}