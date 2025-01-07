using System.Text.Json.Serialization;
using MediatR;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? CategoryId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CategoryType CategoryType { get; set; }
}