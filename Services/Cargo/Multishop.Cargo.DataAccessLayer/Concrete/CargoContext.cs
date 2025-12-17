using Microsoft.EntityFrameworkCore;
using Multishop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DataAccessLayer.Concrete
{
	
		public class CargoContext : DbContext
		{
			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				optionsBuilder.UseSqlServer("Server=localhost,1441 ;Initial Catalog=MultishopCargoDb; User=sa;Password=cmvpEKC*TMNd+6n; TrustServerCertificate=True");
			}
			public DbSet<CargoCompany> CargoCompanies { get; set; }
			public DbSet<CargoOperation> CargoOperations { get; set; }

			public DbSet<CargoCustomer> CargoCustomers { get; set; }
			public DbSet<CargoDetail> CargoDetails { get; set; }
		}
	}




