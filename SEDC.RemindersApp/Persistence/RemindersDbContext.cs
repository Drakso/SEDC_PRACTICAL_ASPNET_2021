using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	// DbContext == Database
	public class RemindersDbContext : DbContext
	{
		public RemindersDbContext(DbContextOptions options) : base(options) { }

		// DbSet<item> == Table of item in database
		public DbSet<Reminder> Reminders { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Configurations
			builder.Entity<Reminder>()
				.HasOne(x => x.User)
				.WithMany(x => x.Reminders)
				.HasForeignKey(x => x.UserId);
		}
	}
}