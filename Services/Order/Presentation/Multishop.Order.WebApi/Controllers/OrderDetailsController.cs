using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using Multishop.Order.Application.Feature.CQRS.Queries.OrderDetailQueries;

namespace Multishop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailQueryHandler _getOrderDetailOueryHandler;
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
		private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
		public OrderDetailsController (GetOrderDetailQueryHandler getOrderDetailOueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
		{
			_getOrderDetailOueryHandler = getOrderDetailOueryHandler;
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
			_removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var result = await _getOrderDetailOueryHandler.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> OrderDetailListById(int id)
		{
			var result = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş bilgisi başarıyla eklendi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş bilgisi başarıyla güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOrderDetail(int id)
		{
			await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
			return Ok("Sipariş bilgisi başarıyla silindi.");
		}
	}
}

