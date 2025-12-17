using MediatR;
using Multishop.Order.Application.Feature.Mediator.Queries.OrderingQueries;
using Multishop.Order.Application.Feature.Mediator.Results.OrderingResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.Mediator.Handlers
{
	public class GetOrderingOueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
	{
		private readonly IRepository<Ordering> _repository;
		public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderingQueryResult
			{
				OrderingId = x.OrderingId,
				OrderDate = x.OrderDate,
				TotalPrice = x.TotalPrice,
				UserId = x.UserId,
			}).ToList();
		}
	}
}
