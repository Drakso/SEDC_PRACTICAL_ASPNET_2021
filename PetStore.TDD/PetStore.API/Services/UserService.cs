using PetStore.API.Data;
using PetStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Services
{
	public class UserService : IUserService
	{
		private IAuthenticationService _authService;

		public UserService(IAuthenticationService authService)
		{
			_authService = authService;
		}

		public string Register(string username, string password)
		{
			var user = new User() { Username = username, Password = password };
			var existingUser = Db.Users.FirstOrDefault(x => x.Username == username);
			if (existingUser != null) throw new Exception("User already exists!");

			Db.Users.Add(user);

			var token = _authService.GenerateToken(DateTime.UtcNow, Guid.NewGuid());
			return token;
		}

		public string LogIn(string username, string password)
		{
			var user = Db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
			if (user == null) throw new Exception("Log in failed!");

			var token = _authService.GenerateToken(DateTime.UtcNow, Guid.NewGuid());
			return token;
		}
	}
}
