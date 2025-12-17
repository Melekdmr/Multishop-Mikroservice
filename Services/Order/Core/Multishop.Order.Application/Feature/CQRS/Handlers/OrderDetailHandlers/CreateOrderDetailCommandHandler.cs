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
	public class CreateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
		{
			await _repository.CreateAsync(new OrderDetail
			{
				ProductAmount = createOrderDetailCommand.ProductAmount,
				OrderingId = createOrderDetailCommand.OrderingId,
				ProductId = createOrderDetailCommand.ProductId,
				ProductName = createOrderDetailCommand.ProductName,
				ProductPrice = createOrderDetailCommand.ProductPrice,
				TotalPrice = createOrderDetailCommand.TotalPrice

			});
		}
	}
}
