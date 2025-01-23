using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.RemovePaymentMethod;

public class RemovePaymentMethodCommandHandler(
    IPaymentMethodService service
    ): IRequestHandler<RemovePaymentMethodCommandRequest, RemovePaymentMethodCommandResponse>
{
    public async Task<RemovePaymentMethodCommandResponse> Handle(RemovePaymentMethodCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemovePaymentMethodAsync(request, cancellationToken);
    }
}