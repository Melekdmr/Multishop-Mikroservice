using MediatR;
using Multishop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.Mediator.Handlers
{
	public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;
		public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
		{
			var values=await _repository.GetByIdAsync(request.Id);
			await _repository.DeleteAsync(values);

		}
	}
}
