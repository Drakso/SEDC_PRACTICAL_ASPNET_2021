using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
	public class AuthenticationHelper : IAuthenticationHelper
	{
		private readonly AppSettings _options;
		public AuthenticationHelper(IOptions<AppSettings> options)
		{
			_options = options.Value;
		}
		public string Authenticate(string clientKey, string appName)
		{
			if (clientKey != _options.RemindersIdentificationKey) throw new Exception("Authentication Failed. Please check your unique client key and try again!");

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_options.Secret);
			var tokenDescription = new SecurityTokenDescriptor()
			{
				Subject = new System.Security.Claims.ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, appName)
				}),
				Expires = DateTime.UtcNow.AddDays(30),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescription);

			return tokenHandler.WriteToken(token);
		}
	}
}
