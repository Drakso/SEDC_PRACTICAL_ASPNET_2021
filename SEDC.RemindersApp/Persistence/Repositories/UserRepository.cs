using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		protected readonly RemindersDbContext _context;
		public UserRepository(RemindersDbContext context)
		{
			_context = context;
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users;
		}

		public User GetById(int id)
		{
			return _context.Users.FirstOrDefault(x => x.Id == id);
		}

		public User GetByLoginInfo(string username, string password)
		{
			return _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
		}

		public int Insert(User user)
		{
			_context.Users.Add(user);
			return _context.SaveChanges();
		}

		public int Update(User user)
		{
			var entity = _context.Users.FirstOrDefault(x => x.Id == user.Id);

			entity.Password = user.Password;
			entity.FirstName = user.FirstName;
			entity.LastName = user.LastName;

			_context.Users.Update(entity);
			return _context.SaveChanges();
		}

		public int Delete(int id)
		{
			var entity = _context.Users.FirstOrDefault(x => x.Id == id);

			_context.Users.Remove(entity);
			return _context.SaveChanges();
		}
	}
}
