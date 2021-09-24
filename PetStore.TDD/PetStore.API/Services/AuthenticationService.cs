using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		// Guid is randomly generated identifier ( as a string )
		// http://myWebsite/Api/GetById/5 // Predictable id
		// http://myWebsite/Api/GetById/sdfsd=kfkipoj23-5fwepfjpo23jri2r // Unpredictable id
		public string GenerateToken(DateTime dateTime, Guid key)
		{
			byte[] time = BitConverter.GetBytes(dateTime.ToBinary());
			byte[] keyBytes = key.ToByteArray();
			string token = Convert.ToBase64String(time.Concat(keyBytes).ToArray());

			return token;
		}

		public bool CheckToken(string token, int daysValid)
		{
			byte[] data = Convert.FromBase64String(token);
			DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
			if (when < DateTime.UtcNow.AddDays(-daysValid))
			{
				return false;
			}

			return true;
		}
	}
}
