using MediatR;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.Mediator.Commands.OrderingCommands
{
	public class UpdateOrderingCommand:IRequest
	{
		public int OrderingId { get; set; }
		public string UserId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }

	}
}
