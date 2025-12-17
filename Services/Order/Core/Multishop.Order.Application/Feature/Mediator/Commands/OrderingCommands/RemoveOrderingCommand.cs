using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.Mediator.Commands.OrderingCommands
{
	public class RemoveOrderingCommand:IRequest
	{
		public RemoveOrderingCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
