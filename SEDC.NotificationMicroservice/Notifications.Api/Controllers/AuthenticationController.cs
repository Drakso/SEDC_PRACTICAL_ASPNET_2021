using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationHelper _authenticationHelper;

		public AuthenticationController(IAuthenticationHelper authenticationHelper)
		{
			_authenticationHelper = authenticationHelper;
		}

		[HttpGet("Authenticate")]
		public IActionResult Authenticate(string appKey, string appName)
		{
			var token = _authenticationHelper.Authenticate(appKey, appName);

			return Ok(token);
		}
	}
}
