using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Cashback.CreateCashback;

public class CreateCashbackCommandHandler(
    ICashbackService service
    ): IRequestHandler<CreateCashbackCommandRequest, CreateCashbackCommandResponse>
{
    public async Task<CreateCashbackCommandResponse> Handle(CreateCashbackCommandRequest request, CancellationToken ct)
    {
        return await service.CreateCashbackAsync(request, ct);
    }
}