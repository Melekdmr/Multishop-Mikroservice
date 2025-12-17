using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Feature.CQRS.Queries.AddressQueries
{
	public class GetAddressByIdOuery
	{

		public int Id { get; set; }

		/*Bu sınıfın bir örneğini oluştururken ID’yi zorunlu hale getirir.ID set edilmeden nesne oluşturulmasını engeller*/
		public GetAddressByIdOuery(int id)
		{
			Id = id;
		}
	}
}
