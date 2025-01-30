using MoneyManager.Application.Features.CQRS.Commands.Cashback.CreateCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.RemoveCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.UpdateCashback;
using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetAllCashback;
using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;

namespace MoneyManager.Application.Services.Entities;

public interface ICashbackService
{
    Task<CreateCashbackCommandResponse> CreateCashbackAsync(CreateCashbackCommandRequest request, CancellationToken ct = default);
    Task<UpdateCashbackCommandResponse> UpdateCashbackAsync(UpdateCashbackCommandRequest request, CancellationToken ct = default);
    Task<RemoveCashbackCommandResponse> RemoveCashbackAsync(RemoveCashbackCommandRequest request, CancellationToken ct = default);
    Task<List<GetAllCashbackQueryResponse>> GetAllCashbackAsync(GetAllCashbackQueryRequest request, CancellationToken ct = default);
    Task<List<GetFilteredCashbackQueryResponse>> FilterCashbackAsync(GetFilteredCashbackQueryRequest request, CancellationToken ct = default);
}