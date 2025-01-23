using MoneyManager.Application.Features.CQRS.Commands.Stock.CreateStock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.RemoveStock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.UpdateStock;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStock;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;

namespace MoneyManager.Application.Services.Entities;

public interface IStockService
{
    Task<CreateStockCommandResponse> CreateStockAsync(CreateStockCommandRequest request, CancellationToken ct = default);
    Task<UpdateStockCommandResponse> UpdateStockAsync(UpdateStockCommandRequest request, CancellationToken ct = default);
    Task<RemoveStockCommandResponse> RemoveStockAsync(RemoveStockCommandRequest request, CancellationToken ct = default);
    Task<List<GetAllStockQueryResponse>> GetAllStocksAsync(GetAllStockQueryRequest request, CancellationToken ct = default);
    Task<List<GetFilteredStockQueryResponse>> FilterStocksAsync(GetFilteredStockQueryRequest request, CancellationToken ct = default);
}