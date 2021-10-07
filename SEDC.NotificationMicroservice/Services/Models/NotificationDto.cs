using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
	public class NotificationDto
	{
		public int Id { get; set; }
		public string Subject { get; set; }
		public string Text { get; set; }
		public string Email { get; set; }
		public bool IsSent { get; set; }
		public DateTime DateSent { get; set; }
	}
}
