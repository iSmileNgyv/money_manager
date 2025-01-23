using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Cashback.RemoveCashback;

public class RemoveCashbackCommandHandler(
    ICashbackService service
    ): IRequestHandler<RemoveCashbackCommandRequest, RemoveCashbackCommandResponse>
{
    public async Task<RemoveCashbackCommandResponse> Handle(RemoveCashbackCommandRequest request, CancellationToken ct)
    {
        return await service.RemoveCashbackAsync(request, ct);
    }
}