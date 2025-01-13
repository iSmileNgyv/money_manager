namespace MoneyManager.Application.Features.CQRS.Queries.Media.GetAllMedia;

public class GetAllMediaQueryResponse
{
    public Guid Id { get; set; }
    public required string Path { get; set; }
    public required string FullPath { get; set; }
    public required string FileName { get; set; }
}