using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Cashback.UpdateCashback;

public class UpdateCashbackCommandRequest: IRequest<UpdateCashbackCommandResponse>
{
    public Guid Id { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Guid? StockId { get; set; }
    public Guid? CategoryId { get; set; }
    public float Percentage { get; set; }
}