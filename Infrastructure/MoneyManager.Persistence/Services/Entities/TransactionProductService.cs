using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.TransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.CreateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.RemoveTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.UpdateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetByTransactionIdTransactionProduct;
using MoneyManager.Application.Repositories.TransactionProduct;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class TransactionProductService(
    ITransactionProductReadRepository readRepository,
    ITransactionProductWriteRepository writeRepository
    ): ITransactionProductService
{
    public async Task<CreateTransactionProductCommandResponse> CreateTransactionProductAsync(CreateTransactionProductCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            TransactionProduct tp = new()
            {
                ProductId = request.ProductId,
                TransactionId = request.TransactionId,
                Quantity = request.Quantity,
                Price = request.Price
            };
            await writeRepository.AddAsync(tp);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<UpdateTransactionProductCommandResponse> UpdateTransactionProductAsync(UpdateTransactionProductCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            TransactionProduct? tp = await readRepository.GetByIdAsync(request.Id);
            if (tp == null)
                throw new TransactionProductNotFoundException();
            tp.Id = request.Id;
            tp.Price = request.Price;
            tp.Quantity = request.Quantity;
            tp.TransactionId = request.TransactionId;
            tp.ProductId = request.ProductId;
            writeRepository.Update(tp);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<RemoveTransactionProductCommandResponse> RemoveTransactionProductAsync(RemoveTransactionProductCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            TransactionProduct? tp = await readRepository.GetByIdAsync(request.Id);
            if (tp == null)
                throw new TransactionProductNotFoundException();
            writeRepository.Remove(tp);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<List<GetAllTransactionProductQueryResponse>> GetAllTransactionProductAsync(GetAllTransactionProductQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<TransactionProduct> tp = readRepository.GetAll(false)
            .Include(p => p.Product)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .OrderByDescending(p => p.CreatedDate);
        return await tp.Select(p => new GetAllTransactionProductQueryResponse
        {
            Id = p.Id,
            ProductId = p.Product.Id,
            ProductName = p.Product.Name,
            TransactionId = p.TransactionId,
            Quantity = p.Quantity,
            Price = p.Price
        }).ToListAsync(ct);
    }

    public async Task<List<GetByTransactionIdTransactionProductQueryResponse>> GetByTransactionIdTransactionProductAsync(GetByTransactionIdTransactionProductQueryRequest request,
        CancellationToken ct = default)
    {
        var tp = readRepository.GetByTransactionIdAsync(request.TransactionId, ct)
            .Take(request.Size)
            .Skip(request.Size * request.Page);

        return await tp.Select(t => new GetByTransactionIdTransactionProductQueryResponse
        {
            Id = t.Id,
            ProductId = t.Product.Id,
            ProductName = t.Product.Name,
            TransactionId = t.TransactionId,
            Quantity = t.Quantity,
            Price = t.Price
        }).ToListAsync(ct);
    }
}