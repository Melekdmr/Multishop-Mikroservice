using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Multishop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Feature.Mediator.Queries.OrderingQueries;

namespace Multishop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderingController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> OrderingList()
		{
			var result = await _mediator.Send(new GetOrderingQuery());
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderingById(int id)
		{
			var result = await _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş başarıyla eklendi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Adres bilgisi başarıyla güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOrdering(int id)
		{
			await _mediator.Send(new RemoveOrderingCommand(id));
			return Ok("Sipariş başarıyla silindi.");
		}
	}
}
