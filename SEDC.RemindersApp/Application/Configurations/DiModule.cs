using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
	public static class DiModule
	{
		public static IServiceCollection Register(IServiceCollection services, string connectionString)
		{
			// Configuring the DI container for IUserService
			// When someone asks for IUserService in a constructor, the DI contaier will create new UserService() instance
			services.AddTransient<IUserService, UserService>(); // always provides new instance for IUserService
			//services.AddScoped<IUserService, UserService>(); // always provides new instance per request
			//services.AddSingleton<IUserService, UserService>(); // always provides the same ONE instance
		
			services.AddTransient<IReminderService, ReminderService>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IReminderRepository, ReminderRepository>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();

			// Add external configuration
			// External configuraiton for context of Entity Framework
			// When you request in constructor for RemindersDbContext, you will get new instance of the context with SQLServer configured
			services.AddDbContext<RemindersDbContext>(x => x.UseSqlServer(connectionString));

			return services;

		}
	}
}
