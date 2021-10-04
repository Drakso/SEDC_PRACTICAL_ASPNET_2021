using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class ReminderRepository : IReminderRepository
	{
		protected readonly RemindersDbContext _context;
		public ReminderRepository(RemindersDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Reminder> GetAll(int userId)
		{
			return _context.Reminders.Include(x => x.User).Where(x => x.UserId == userId);
		}

		public Reminder GetById(int id)
		{
			return _context.Reminders.Include(x => x.User).FirstOrDefault(x => x.Id == id);
		}

		public int Insert(Reminder reminder)
		{
			_context.Reminders.Add(reminder);
			return _context.SaveChanges();
		}

		public int Update(Reminder reminder)
		{
			var entity = _context.Reminders.FirstOrDefault(x => x.Id == reminder.Id);
			entity.DateTime = reminder.DateTime;
			entity.Title = reminder.Title;
			entity.Description = reminder.Description;
			entity.Priority = reminder.Priority;

			_context.Reminders.Update(entity);
			return _context.SaveChanges();
		}

		public int Delete(int id)
		{
			var entity = _context.Reminders.FirstOrDefault(x => x.Id == id);
			_context.Reminders.Remove(entity);
			return _context.SaveChanges();
		}
	}
}
