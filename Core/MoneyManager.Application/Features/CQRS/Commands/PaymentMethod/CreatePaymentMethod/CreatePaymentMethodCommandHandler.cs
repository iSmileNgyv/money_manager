using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.CreatePaymentMethod;

public class CreatePaymentMethodCommandHandler(
    IPaymentMethodService service
    ): IRequestHandler<CreatePaymentMethodCommandRequest, CreatePaymentMethodCommandResponse>
{
    public async Task<CreatePaymentMethodCommandResponse> Handle(CreatePaymentMethodCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreatePaymentMethodAsync(request, cancellationToken);
    }
}