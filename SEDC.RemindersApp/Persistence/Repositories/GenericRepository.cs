using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly RemindersDbContext _context;
		private readonly DbSet<T> _entities;

		public GenericRepository(RemindersDbContext context)
		{
			_context = context;
			// Inside this variable will be the quivalent of _context.Users if T is User
			// Inside this variable will be the quivalent of _context.Reminders if T is Reminder
			_entities = _context.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return _entities;
		}

		public T GetById(int id)
		{
			return _entities.FirstOrDefault(x => x.Id == id);
		}

		public void Insert(T entity)
		{
			_entities.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_entities.Update(entity);
			_context.SaveChanges();	
		}

		public void Delete(T entity)
		{
			_entities.Remove(entity);
			_context.SaveChanges();
		}

	}
}
