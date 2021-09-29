using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public interface IUserRepository
	{
		IEnumerable<User> GetAll();
		User GetById(int id);
		User GetByLoginInfo(string username, string password);
		int Insert(User user);
		int Update(User user);
		int Delete(int id);
	}
}