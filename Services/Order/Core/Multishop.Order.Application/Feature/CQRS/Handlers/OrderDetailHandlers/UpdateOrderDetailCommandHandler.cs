using Multishop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
	public class UpdateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.OrderDetailId);
			
			value.ProductAmount = command.ProductAmount;
			value.OrderingId = command.OrderingId;
			value.ProductId = command.ProductId;
			value.ProductName = command.ProductName;
			value.ProductPrice = command.ProductPrice;
			value.TotalPrice = command.TotalPrice;
			await _repository.UpdateAsync(value);
		}
	}
}

