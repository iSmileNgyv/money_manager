using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.UpdatePaymentMethod;

public class UpdatePaymentMethodCommandHandler(
    IPaymentMethodService service
    ): IRequestHandler<UpdatePaymentMethodCommandRequest, UpdatePaymentMethodCommandResponse>
{
    public async Task<UpdatePaymentMethodCommandResponse> Handle(UpdatePaymentMethodCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.UpdatePaymentMethodAsync(request, cancellationToken);
    }
}