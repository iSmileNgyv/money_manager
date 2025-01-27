using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.Transaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.CreateTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.UpdateTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;
using MoneyManager.Application.Repositories.Transaction;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class TransactionService(
    ITransactionWriteRepository writeRepository,
    ITransactionReadRepository readRepository
    ): ITransactionService
{
    public async Task<CreateTransactionCommandResponse> CreateTransactionAsync(CreateTransactionCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Transaction transaction = new()
            {
                PaymentMethodId = request.PaymentMethodId,
                CategoryId = request.CategoryId,
                StockId = request.StockId,
                Amount = request.Amount,
                CashbackAmount = request.CashbackAmount
            };
            await writeRepository.AddAsync(transaction);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();

    }

    public async Task<UpdateTransactionCommandResponse> UpdateTransactionAsync(UpdateTransactionCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Transaction transaction = new()
            {
                PaymentMethodId = request.PaymentMethodId,
                CategoryId = request.CategoryId,
                StockId = request.StockId,
                Amount = request.Amount,
                CashbackAmount = request.CashbackAmount
            };
            writeRepository.Update(transaction);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<RemoveTransactionCommandResponse> RemoveTransactionAsync(RemoveTransactionCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            var transaction = await readRepository.GetByIdAsync(request.Id);
            if (transaction == null)
                throw new TransactionNotFoundException();
            writeRepository.Remove(transaction);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }
        return new();
    }

    public async Task<List<GetAllTransactionQueryResponse>> GetAllTransactionAsync(GetAllTransactionQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<Transaction> transaction = readRepository.GetAll(false)
            .Include(t => t.PaymentMethod)
            .Include(t => t.Category)
            .Include(t => t.Stock)
            .Take(request.Size)
            .Skip(request.Page * request.Size);

        return await transaction.Select(t => new GetAllTransactionQueryResponse
        {
            Id = t.Id,
            PaymentMethodId = t.PaymentMethodId,
            PaymentMethodName = t.PaymentMethod.Name,
            CategoryId = t.CategoryId,
            CategoryName = t.Category.Name,
            StockId = t.StockId,
            StockName = t.Stock!.Name,
            Amount = t.Amount,
            CashbackAmount = t.CashbackAmount
        }).ToListAsync(ct);
    }
}