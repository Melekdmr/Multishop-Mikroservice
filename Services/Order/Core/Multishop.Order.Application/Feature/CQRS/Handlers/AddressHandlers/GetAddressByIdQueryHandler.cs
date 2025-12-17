using Multishop.Order.Application.Feature.CQRS.Queries.AddressQueries;
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
	public class GetAddressByIdQueryHandler
	{
		private readonly IRepository<Address> _repository;

		public GetAddressByIdQueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}
		 /*Id ye göre veri getirme */
		public async Task <GetAddressByIdQueryResult> Handle(GetAddressByIdOuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAddressByIdQueryResult
			{
				AddressId = values.AddressId,
				City = values.City,
				District = values.District,
				Detail = values.Detail,
				UserId = values.UserId,

			};
		}
	}
}