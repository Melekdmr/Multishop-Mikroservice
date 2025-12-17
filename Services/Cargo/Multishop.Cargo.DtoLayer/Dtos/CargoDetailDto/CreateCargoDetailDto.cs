using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DtoLayer.CargoDetailCompany
{
	public class CreateCargoDetailDto
	{
		
		public string SenderCustomer { get; set; }
		public string ReceiverCustomer { get; set; } //Alıcı

		public string Barcode { get; set; }
		public int CargoCompanyId { get; set; }
	
	}
}
