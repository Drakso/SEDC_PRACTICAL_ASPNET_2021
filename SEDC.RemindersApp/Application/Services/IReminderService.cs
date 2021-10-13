using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public interface IReminderService
	{
		List<ReminderDTO> GetAll(int userId);
		bool Insert(ReminderDTO reminder);
		bool Delete(int reminderId);
		ReminderDTO GetById(int reminderId);
	}
}
