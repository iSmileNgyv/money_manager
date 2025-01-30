using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.CreateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.RemoveTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.UpdateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetByTransactionIdTransactionProduct;

namespace MoneyManager.Application.Services.Entities;

public interface ITransactionProductService
{
    Task<CreateTransactionProductCommandResponse> CreateTransactionProductAsync(CreateTransactionProductCommandRequest request, CancellationToken ct = default);
    Task<UpdateTransactionProductCommandResponse> UpdateTransactionProductAsync(UpdateTransactionProductCommandRequest request, CancellationToken ct = default);
    Task<RemoveTransactionProductCommandResponse> RemoveTransactionProductAsync(RemoveTransactionProductCommandRequest request, CancellationToken ct = default);
    Task<List<GetAllTransactionProductQueryResponse>> GetAllTransactionProductAsync(GetAllTransactionProductQueryRequest request, CancellationToken ct = default);
    Task<List<GetByTransactionIdTransactionProductQueryResponse>> GetByTransactionIdTransactionProductAsync(GetByTransactionIdTransactionProductQueryRequest request, CancellationToken ct = default);
}