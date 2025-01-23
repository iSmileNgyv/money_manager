using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Cashback.RemoveCashback;

public class RemoveCashbackCommandRequest: IRequest<RemoveCashbackCommandResponse>
{
    public Guid Id { get; set; }
}