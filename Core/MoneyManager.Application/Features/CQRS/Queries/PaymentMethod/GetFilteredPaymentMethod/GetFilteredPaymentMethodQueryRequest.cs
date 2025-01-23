using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;

public class GetFilteredPaymentMethodQueryRequest: IRequest<List<GetFilteredPaymentMethodQueryResponse>>
{
    public string? Name { get; set; }
}