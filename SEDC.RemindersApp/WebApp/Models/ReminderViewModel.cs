using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
	public class ReminderViewModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string DateTime { get; set; }
		public Priority Priority { get; set; }
		public string PriorityName { get; set; }
		public string Color { get; set; }
	}
}
