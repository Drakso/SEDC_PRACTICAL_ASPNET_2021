using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		public string GenerateToken(int userId)
		{
			byte[] id = BitConverter.GetBytes(userId);
			byte[] key = Guid.NewGuid().ToByteArray();
			string token = Convert.ToBase64String(id.Concat(key).ToArray());

			return token;
		}
		
		public int GetUserIdFromToken(string token)
		{
			if (token == "" || token == null) return -1;

			byte[] data = Convert.FromBase64String(token);
			int userId = BitConverter.ToInt32(data, 0);

			return userId;
		}
	}
}
