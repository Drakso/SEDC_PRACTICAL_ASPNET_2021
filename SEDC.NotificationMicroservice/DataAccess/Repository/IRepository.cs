using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IRepository<T> where T : BaseEntity
	{
		// Func is a delegate and it returns bool and accepts a parameter of type T
		// This is a generic method for getting all from database
		// We can also get all but add some filter with the expression
		// Since the expression is nullable, if we send nothing we will just return all
		IEnumerable<T> GetAll(Func<T, bool>? expression);
		T GetById(int id);
		void Insert(T entity);
		void Insert(IEnumerable<T> entity);
		void Update(T entity);
		void Update(IEnumerable<T> entity);
		void Delete(T entity);
	}
}
