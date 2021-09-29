using Application.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class UserService
	{
		private readonly AppSettings _options;
		public UserService(IOptions<AppSettings> options)
		{
			_options = options.Value;
		}
		public void DoSomethingWithSecret()
		{
			// Use some secret from configuration
			var x = _options.Secret;
		}
	}
}
