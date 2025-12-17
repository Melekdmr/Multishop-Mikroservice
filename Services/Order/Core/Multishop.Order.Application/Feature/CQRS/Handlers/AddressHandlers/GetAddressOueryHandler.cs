using Multishop.Order.Application.Feature.CQRS.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.CQRS.Handlers.AddressHandlers
{
	public class GetAddressOueryHandler
	{
		private readonly IRepository<Address> _repository;

		public GetAddressOueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAddressQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAddressQueryResult
			{
				AddressId = x.AddressId,
				UserId = x.UserId,
				City = x.City,
				District = x.District,
				Detail = x.Detail,
			}).ToList();
				
			
		}
	}
}

