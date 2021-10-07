using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class NotificationDbContext : DbContext
	{
		public NotificationDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Notification> Notifications { get; set; }
	}
}
