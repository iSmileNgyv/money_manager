using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Cashback.CreateCashback;

public class CreateCashbackCommandRequest: IRequest<CreateCashbackCommandResponse>
{
    public Guid PaymentMethodId { get; set; }
    public Guid? StockId { get; set; }
    public Guid? CategoryId { get; set; }
    public float Percentage { get; set; }
}