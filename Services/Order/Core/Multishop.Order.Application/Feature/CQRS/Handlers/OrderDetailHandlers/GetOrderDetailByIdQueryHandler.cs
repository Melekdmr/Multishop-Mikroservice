
using Multishop.Order.Application.Feature.CQRS.Queries.OrderDetailQueries;
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
	public class GetOrderDetailByIdQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		/*Id ye göre veri getirme */
		public async Task<GetOrderDetailQueryResult> Handle(GetOrderDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetOrderDetailQueryResult
			{
				ProductAmount = values.ProductAmount,
				ProductName = values.ProductName,
				ProductId = values.ProductId,
				TotalPrice = values.TotalPrice,
				OrderDetailId = values.OrderDetailId,
				OrderingId = values.OrderingId,
				ProductPrice = values.ProductPrice,

			};
		}
	}
}
