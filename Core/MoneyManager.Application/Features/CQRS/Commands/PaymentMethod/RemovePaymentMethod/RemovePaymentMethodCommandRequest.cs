using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.RemovePaymentMethod;

public class RemovePaymentMethodCommandRequest: IRequest<RemovePaymentMethodCommandResponse>
{
    public Guid Id { get; set; }
}