using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
	public class RemindersHomeViewModel
	{
		public List<ReminderViewModel> Reminders { get; set; }

		public RemindersHomeViewModel()
		{
			Reminders = new List<ReminderViewModel>();
		}
	}
}
