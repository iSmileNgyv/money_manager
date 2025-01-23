using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.CreatePaymentMethod;

public class CreatePaymentMethodCommandRequest: IRequest<CreatePaymentMethodCommandResponse>
{
    public required string Name { get; set; }
    public string? Image { get; set; }
}