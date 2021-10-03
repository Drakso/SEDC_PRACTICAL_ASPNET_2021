using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Reminder : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DateTime { get; set; }
	    public Priority Priority { get; set; }
		public User User { get; set; }
		public int UserId { get; set; }

		// Soft Delete
		// Every time we want to soft delete something from the DB we turn this field in to TRUE
		// All functions ( GetAll, GetById, etc. ) are developed to SKIP all records that have IsDeleted == TRUE
		// This way the user does not see soft deleted items, but you still have them in the DB

		// public bool IsDeleted { get; set; }
	}
}
