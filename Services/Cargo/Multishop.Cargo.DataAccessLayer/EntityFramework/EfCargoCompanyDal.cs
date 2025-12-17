using Multishop.Cargo.DataAccessLayer.Abstract;
using Multishop.Cargo.DataAccessLayer.Concrete;
using Multishop.Cargo.DataAccessLayer.Repositories;
using Multishop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DataAccessLayer.EntityFramework
{
	public  class EfCargoCompanyDal:GenericRepository<CargoCompany>,ICargoCompanyDal
	{
		public EfCargoCompanyDal(CargoContext contex):base(contex)
		{
			
		}
	}
}
