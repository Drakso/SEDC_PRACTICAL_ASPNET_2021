using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
	public interface IAuthenticationHelper
	{
		string Authenticate(string clientKey, string appName);
	}
}
