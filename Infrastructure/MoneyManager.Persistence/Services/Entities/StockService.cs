using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.Stock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.CreateStock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.RemoveStock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.UpdateStock;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStock;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStockWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;
using MoneyManager.Application.Repositories.Stock;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class StockService(
    IStockWriteRepository writeRepository,
    IStockReadRepository readRepository,
    IConfiguration configuration
    ): IStockService
{
    public async Task<CreateStockCommandResponse> CreateStockAsync(CreateStockCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Stock stock = new()
            {
                Name = request.Name,
                Image = request.Image
            };
            await writeRepository.AddAsync(stock);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<UpdateStockCommandResponse> UpdateStockAsync(UpdateStockCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Stock stock = new()
            {
                Id = request.Id,
                Name = request.Name,
                Image = request.Image
            };
            writeRepository.Update(stock);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<RemoveStockCommandResponse> RemoveStockAsync(RemoveStockCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Stock? stock = await readRepository.GetByIdAsync(request.Id, false);
            if (stock == null)
                throw new StockNotFoundException();
            writeRepository.Remove(stock);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<List<GetAllStockQueryResponse>> GetAllStocksAsync(GetAllStockQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<Stock> stocks = readRepository.GetAll(false)
            .Take(request.Size)
            .Skip(request.Page * request.Size);
        return await stocks.Select(s => new GetAllStockQueryResponse
        {
            Id = s.Id,
            Name = s.Name,
            Image = new ImageResponse {Path = s.Image, FullPath = configuration["BaseStorageUrl"] + "/" +s.Image },
            CreatedDate = s.CreatedDate
        }).ToListAsync(ct);
    }

    public async Task<List<GetFilteredStockQueryResponse>> FilterStocksAsync(GetFilteredStockQueryRequest request, CancellationToken ct = default)
    {
        List<Stock> stocks = await readRepository.FilterAsync(request, ct);
        return stocks.Select(s => new GetFilteredStockQueryResponse
        {
            Id = s.Id,
            Name = s.Name,
            Image = new ImageResponse {Path = s.Image, FullPath = configuration["BaseStorageUrl"] + "/" +s.Image },
            CreatedDate = s.CreatedDate
        }).ToList();
    }

    public async Task<List<GetAllStockWithoutPaginationQueryResponse>> GetAllStocksWithoutPaginationAsync(GetAllStockWithoutPaginationQueryRequest request,
        CancellationToken ct = default)
    {
        var stocks = readRepository.GetAll(false);
        return await stocks.Select(s => new GetAllStockWithoutPaginationQueryResponse
        {
            Id = s.Id,
            Name = s.Name
        }).ToListAsync(ct);
    }
}