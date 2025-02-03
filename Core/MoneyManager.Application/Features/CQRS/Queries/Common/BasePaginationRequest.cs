namespace MoneyManager.Application.Features.CQRS.Queries.Common;

public class BasePaginationRequest
{
    public int Page { get; set; }
    public int Size { get; set; }
}