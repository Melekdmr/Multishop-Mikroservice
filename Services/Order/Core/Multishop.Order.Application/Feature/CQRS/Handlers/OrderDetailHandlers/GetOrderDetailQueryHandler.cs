using Multishop.Order.Application.Feature.CQRS.Results.AddressResults;
using Multishop.Order.Application.Feature.CQRS.Results.OrderDetailResult;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderDetailQueryResult
			{
				OrderDetailId = x.OrderDetailId,
				ProductAmount = x.ProductAmount,
				OrderingId = x.OrderingId,
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				ProductPrice = x.ProductPrice,
				TotalPrice = x.TotalPrice
			}).ToList();
		}
	}
}
