using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.CQRS.Commands.AddressCommands
{
	public class RemoveAddressCommand
	{
		public RemoveAddressCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }

		
	}
}
