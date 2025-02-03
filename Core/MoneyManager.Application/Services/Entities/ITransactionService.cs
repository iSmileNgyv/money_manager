using MoneyManager.Application.Features.CQRS.Commands.Transaction.CreateTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.UpdateTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;

namespace MoneyManager.Application.Services.Entities;

public interface ITransactionService
{
    Task<CreateTransactionCommandResponse> CreateTransactionAsync(CreateTransactionCommandRequest request,
        CancellationToken ct = default);
    Task<UpdateTransactionCommandResponse> UpdateTransactionAsync(UpdateTransactionCommandRequest request, CancellationToken ct = default);
    Task<RemoveTransactionCommandResponse> RemoveTransactionAsync(RemoveTransactionCommandRequest request, CancellationToken ct = default);
    Task<List<GetAllTransactionQueryResponse>> GetAllTransactionAsync(GetAllTransactionQueryRequest request, CancellationToken ct = default);
    Task<List<GetFilteredTransactionQueryResponse>> GetFilteredTransactionAsync(GetFilteredTransactionQueryRequest request, CancellationToken ct = default);
}