using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Cashback.UpdateCashback;

public class UpdateCashbackCommandHandler(
    ICashbackService service
    ): IRequestHandler<UpdateCashbackCommandRequest, UpdateCashbackCommandResponse>
{
    public async Task<UpdateCashbackCommandResponse> Handle(UpdateCashbackCommandRequest request, CancellationToken ct)
    {
        return await service.UpdateCashbackAsync(request, ct);
    }
}