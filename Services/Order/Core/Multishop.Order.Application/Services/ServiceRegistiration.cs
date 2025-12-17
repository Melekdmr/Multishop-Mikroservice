using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Services
{
	public static class ServiceRegistiration
	{
		public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
		{ //ilgili kütüphanenin registiration'u sağlar.
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
		}
	}
}
