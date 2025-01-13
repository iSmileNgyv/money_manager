using System.Text.Json.Serialization;
using MediatR;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;

public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public Guid? CategoryId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CategoryType CategoryType { get; set; }
}