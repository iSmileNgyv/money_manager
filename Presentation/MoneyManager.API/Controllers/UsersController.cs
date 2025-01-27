using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.User.CreateUser;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(
    IMediator mediator
    ) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}