using DataAccess;
using DataAccess.Domain;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
	public static class DiModuleRegister
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddTransient<IReceiverService, ReceiverService>();
			services.AddTransient<ISenderService, SenderService>();

			return services;
		}

		public static IServiceCollection RegisterRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRepository<Notification>, Repository<Notification>>();

			return services;
		}

		public static IServiceCollection RegisterContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<NotificationDbContext>(x => x.UseSqlServer(connectionString));

			return services;
		}
	}
}
