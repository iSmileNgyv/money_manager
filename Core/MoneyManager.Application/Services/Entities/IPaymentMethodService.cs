using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.CreatePaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.RemovePaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.UpdatePaymentMethod;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethod;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;

namespace MoneyManager.Application.Services.Entities;

public interface IPaymentMethodService
{
    Task<CreatePaymentMethodCommandResponse> CreatePaymentMethodAsync(CreatePaymentMethodCommandRequest request, CancellationToken ct = default);
    Task<UpdatePaymentMethodCommandResponse> UpdatePaymentMethodAsync(UpdatePaymentMethodCommandRequest request, CancellationToken ct = default);
    Task<RemovePaymentMethodCommandResponse> RemovePaymentMethodAsync(RemovePaymentMethodCommandRequest request, CancellationToken ct = default);
    Task<List<GetAllPaymentMethodQueryResponse>> GetAllPaymentMethodsAsync(GetAllPaymentMethodQueryRequest request, CancellationToken ct = default);
    Task<List<GetFilteredPaymentMethodQueryResponse>> GetFilteredPaymentMethodsAsync(GetFilteredPaymentMethodQueryRequest request, CancellationToken ct = default);
}