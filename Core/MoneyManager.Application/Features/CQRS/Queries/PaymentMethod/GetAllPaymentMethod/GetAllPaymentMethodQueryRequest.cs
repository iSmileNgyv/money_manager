using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethod;

public class GetAllPaymentMethodQueryRequest: IRequest<List<GetAllPaymentMethodQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}