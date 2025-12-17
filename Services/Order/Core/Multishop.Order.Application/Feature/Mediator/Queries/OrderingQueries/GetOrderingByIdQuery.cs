using MediatR;
using Multishop.Order.Application.Feature.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.Mediator.Queries.OrderingQueries
{
	public  class GetOrderingByIdQuery:IRequest<GetOrderingByIdQueryResult>
	{
		public GetOrderingByIdQuery(int id)
		{
		Id= id;
		}

		public int Id { get; set; }
	}
}
