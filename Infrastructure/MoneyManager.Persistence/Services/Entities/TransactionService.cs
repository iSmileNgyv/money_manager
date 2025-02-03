using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.Transaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.CreateTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.UpdateTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;
using MoneyManager.Application.Repositories.Transaction;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Application.Services.Log;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class TransactionService(
    ITransactionWriteRepository writeRepository,
    ITransactionReadRepository readRepository,
    IConfiguration configuration,
    ILogService logService
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
                EventDate = request.EventDate,
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
            logService.LogInformation("transaction update before", request);
            Transaction? transaction = await readRepository.GetByIdAsync(request.Id, false);
            if (transaction == null)
                throw new TransactionNotFoundException();
            transaction.PaymentMethodId = request.PaymentMethodId;
            transaction.CategoryId = request.CategoryId;
            transaction.StockId = request.StockId;
            transaction.Amount = request.Amount;
            transaction.EventDate = request.EventDate;
            transaction.CashbackAmount = request.CashbackAmount;
            logService.LogInformation("transaction update after", transaction);
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
            var transaction = await readRepository.GetByIdAsync(request.Id, false);
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
            .OrderByDescending(t => t.EventDate)
            .ThenByDescending(t => t.CreatedDate)
            .Take(request.Size)
            .Skip(request.Page * request.Size);

        return await transaction.Select(t => new GetAllTransactionQueryResponse
        {
            Id = t.Id,
            PaymentMethodId = t.PaymentMethodId,
            PaymentMethodName = t.PaymentMethod.Name,
            PaymentMethodImage = new ImageResponse {Path = t.PaymentMethod.Image, FullPath = configuration["BaseStorageUrl"] + "/" + t.PaymentMethod.Image },
            CategoryId = t.CategoryId,
            CategoryName = t.Category.Name,
            CategoryImage = new ImageResponse {Path = t.Category.Image, FullPath = configuration["BaseStorageUrl"] + "/" +t.Category.Image },
            StockId = t.StockId,
            StockName = t.Stock!.Name,
            StockImage = new ImageResponse {Path = t.Stock.Image, FullPath = configuration["BaseStorageUrl"] + "/" +t.Stock.Image },
            Amount = t.Amount,
            EventDate = t.EventDate,
            CashbackAmount = t.CashbackAmount,
            CreatedDate = t.CreatedDate
        }).ToListAsync(ct);
    }

    public async Task<List<GetFilteredTransactionQueryResponse>> GetFilteredTransactionAsync(GetFilteredTransactionQueryRequest request, CancellationToken ct = default)
    {
        List<Transaction> transactions = await readRepository.FilterAsync(request, ct);
        logService.LogInformation("transaction filter request", request);
        logService.LogInformation("transaction filter response", transactions);
        return transactions.Select(t => new GetFilteredTransactionQueryResponse
        {
            Id = t.Id,
            PaymentMethodId = t.PaymentMethodId,
            PaymentMethodName = t.PaymentMethod.Name,
            PaymentMethodImage = new ImageResponse {Path = t.PaymentMethod.Image, FullPath = configuration["BaseStorageUrl"] + "/" + t.PaymentMethod.Image },
            CategoryId = t.CategoryId,
            CategoryName = t.Category.Name,
            CategoryImage = new ImageResponse {Path = t.Category.Image, FullPath = configuration["BaseStorageUrl"] + "/" +t.Category.Image },
            StockId = t.StockId,
            StockName = t.Stock?.Name,
            StockImage = new ImageResponse {Path = t.Stock?.Image, FullPath = configuration["BaseStorageUrl"] + "/" +t.Stock?.Image },
            Amount = t.Amount,
            EventDate = t.EventDate,
            CashbackAmount = t.CashbackAmount,
            CreatedDate = t.CreatedDate
        }).ToList();
    }
}