using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;
using Multishop.Order.Application.Feature.CQRS.Queries.AddressQueries;

namespace Multishop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly GetAddressOueryHandler _getAddressOueryHandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
		private readonly CreateAddressCommandHandler _createAddressCommandHandler;
		private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
		private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
		public AddressesController(GetAddressOueryHandler getAddressOueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
		{
			_getAddressOueryHandler = getAddressOueryHandler;
			_getAddressByIdQueryHandler = getAddressByIdQueryHandler;
			_createAddressCommandHandler = createAddressCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
			_removeAddressCommandHandler = removeAddressCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			var result = await _getAddressOueryHandler.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> AddressListById(int id)
		{
			var result = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdOuery(id));
			return Ok(result);
		}
		[HttpPost]
       public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
		{
			await _createAddressCommandHandler.Handle(command);
			return Ok("Adres bilgisi başarıyla eklendi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
		{
			await _updateAddressCommandHandler.Handle(command);
			return Ok("Adres bilgisi başarıyla güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			 await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
			return Ok("Adres bilgisi başarıyla silindi.");
		}
	}
}
