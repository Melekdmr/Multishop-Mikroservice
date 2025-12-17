using Multishop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Multishop.Order.Application.Feature.CQRS.Handlers.AddressHandlers
{
	public class UpdateAddressCommandHandler
	{

		private readonly IRepository<Address> _repository;

		public UpdateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAddressCommand command)
		{
			var value = await _repository.GetByIdAsync(command.AddressId);
			value.City = command.City;
			value.District = command.District;
			value.Detail = command.Detail;
			value.UserId = command.UserId;
			await _repository.UpdateAsync(value);
		}
	}
}
