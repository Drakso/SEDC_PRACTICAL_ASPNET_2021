using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly NotificationDbContext _context;
		private readonly DbSet<T> _set;

		public Repository(NotificationDbContext context)
		{
			_context = context;
			_set = _context.Set<T>(); // This finds the set of the entity we provide in T
									  // This is basically the same as context.Users or context.Reminders or context.Notifications
		}

		public IEnumerable<T> GetAll(Func<T, bool>? expression)
		{
			var result = expression == null ? _set.AsEnumerable() : _set.Where(expression);

			return result;
		}

		public T GetById(int id)
		{
			return _set.SingleOrDefault(x => x.Id == id);
		}

		public void Insert(T entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");

			_set.Add(entity);
			_context.SaveChanges();
		}

		public void Insert(IEnumerable<T> entities)
		{
			if (entities == null) throw new ArgumentNullException("entity");

			_set.AddRange(entities);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");

			_set.Update(entity);
			_context.SaveChanges();
		}

		public void Update(IEnumerable<T> entities)
		{
			if (entities == null) throw new ArgumentNullException("entity");

			_set.UpdateRange(entities);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");

			_set.Remove(entity);
			_context.SaveChanges();
		}
	}
}
