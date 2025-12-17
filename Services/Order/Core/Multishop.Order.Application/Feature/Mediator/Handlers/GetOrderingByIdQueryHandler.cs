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
	public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
	{
		private readonly IRepository<Ordering> _repository;

		public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetOrderingByIdQueryResult
			{
				OrderDate = values.OrderDate,
				OrderingId = values.OrderingId,
				TotalPrice = values.TotalPrice,
				UserId = values.UserId,
			};
		}
	}
}
