using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.Cashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.CreateCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.RemoveCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.UpdateCashback;
using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetAllCashback;
using MoneyManager.Application.Repositories.Cashback;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class CashbackService(
    ICashbackReadRepository readRepository,
    ICashbackWriteRepository writeRepository
    ): ICashbackService
{
    public async Task<CreateCashbackCommandResponse> CreateCashbackAsync(CreateCashbackCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Cashback cashback = new()
            {
                PaymentMethodId = request.PaymentMethodId,
                StockId = request.StockId,
                CategoryId = request.CategoryId,
                Percentage = request.Percentage
            };
            await writeRepository.AddAsync(cashback);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<UpdateCashbackCommandResponse> UpdateCashbackAsync(UpdateCashbackCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Cashback cashback = new()
            {
                Id = request.Id,
                PaymentMethodId = request.PaymentMethodId,
                StockId = request.StockId,
                CategoryId = request.CategoryId,
                Percentage = request.Percentage
            };
            writeRepository.Update(cashback);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<RemoveCashbackCommandResponse> RemoveCashbackAsync(RemoveCashbackCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Cashback? cashback = await readRepository.GetByIdAsync(request.Id);
            if (cashback == null)
                throw new CashbackNotFoundException();
            writeRepository.Remove(cashback);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }
        return new();
    }

    public async Task<List<GetAllCashbackQueryResponse>> GetAllCashbackAsync(GetAllCashbackQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<Cashback> cashbacks = readRepository.GetAll(false)
            .Include(c => c.Stock)
            .Include(c => c.Category)
            .Include(c => c.PaymentMethod)
            .Take(request.Size)
            .Skip(request.Page * request.Size);
        return await cashbacks.Select(c => new GetAllCashbackQueryResponse
        {
            Id = c.Id,
            PaymentMethodName = c.PaymentMethod.Name,
            PaymentMethodId = c.PaymentMethodId,
            CategoryName = c.Category!.Name,
            CategoryId = c.CategoryId,
            Percentage = c.Percentage,
            StockId = c.StockId,
            StockName = c.Stock!.Name,
            CreatedDate = c.CreatedDate
        }).ToListAsync(ct);
    }
}