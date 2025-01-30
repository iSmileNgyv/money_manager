using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.CreateCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.RemoveCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.UpdateCashback;
using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetAllCashback;
using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Authorize(AuthenticationSchemes = "Admin")]
public class CashbacksController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCashbackCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCashbackCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(RemoveCashbackCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllCashbackQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetFilter([FromQuery] GetFilteredCashbackQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}