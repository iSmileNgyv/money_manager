using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.User.Loginuser;
using MoneyManager.Application.Features.CQRS.Commands.User.RefreshTokenLogin;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(
    IMediator mediator
    ) : Controller
{
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginUserCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpPost("refresh-token-login")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}