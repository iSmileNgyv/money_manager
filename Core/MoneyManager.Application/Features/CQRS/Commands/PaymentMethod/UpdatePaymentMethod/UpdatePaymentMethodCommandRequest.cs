using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.UpdatePaymentMethod;

public class UpdatePaymentMethodCommandRequest: IRequest<UpdatePaymentMethodCommandResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
}