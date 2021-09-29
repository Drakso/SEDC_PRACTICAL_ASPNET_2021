using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public interface IReminderRepository
	{
		IEnumerable<Reminder> GetAll();
		Reminder GetById(int id);
		int Insert(Reminder reminder);
		int Update(Reminder reminder);
		int Delete(int id);
	}
}
