using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public interface IReminderService
	{
		List<ReminderDTO> GetAll();
		bool Insert(ReminderDTO reminder);
		bool Delete(int reminderId);
	}
}
