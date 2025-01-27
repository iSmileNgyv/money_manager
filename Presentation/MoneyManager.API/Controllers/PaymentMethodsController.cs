using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.CreatePaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.RemovePaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.UpdatePaymentMethod;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethod;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethodWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Authorize(AuthenticationSchemes = "Admin")]
public class PaymentMethodsController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentMethodCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePaymentMethodCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(RemovePaymentMethodCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllPaymentMethodQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetFilter([FromQuery] GetFilteredPaymentMethodQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPaymentMethodWithoutPaginationQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}