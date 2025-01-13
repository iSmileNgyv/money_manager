using MediatR;
using Microsoft.AspNetCore.Http;

namespace MoneyManager.Application.Features.CQRS.Commands.Media.CreateMedia;

public class CreateMediaCommandRequest : IRequest<List<CreateMediaCommandResponse>>
{
    public required IFormFileCollection Files { get; set; }
}