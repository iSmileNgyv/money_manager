namespace MoneyManager.Application.Features.CQRS.Commands.Media.CreateMedia;

public class CreateMediaCommandResponse
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
}