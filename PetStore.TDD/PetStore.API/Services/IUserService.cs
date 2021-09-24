using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.API.Services
{
	public interface IUserService
	{
		string Register(string username, string password);
		string LogIn(string username, string password);
	}
}
