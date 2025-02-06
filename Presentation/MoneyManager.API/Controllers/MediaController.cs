using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Media.CreateMedia;
using MoneyManager.Application.Features.CQRS.Commands.Media.RemoveMedia;
using MoneyManager.Application.Features.CQRS.Queries.Media.GetAllMedia;

namespace MoneyManager.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class MediaController(
    IMediator mediator
    ) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Upload(CreateMediaCommandRequest request)
    {
        request.Files = Request.Form.Files;
        return Ok(await mediator.Send(request));
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllMediaQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(RemoveMediaCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}