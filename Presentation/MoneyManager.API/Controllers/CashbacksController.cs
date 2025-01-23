using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.CreateCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.RemoveCashback;
using MoneyManager.Application.Features.CQRS.Commands.Cashback.UpdateCashback;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
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
}