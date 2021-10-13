using AutoMapper;
using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	// C# Naming conventions:
	// Naming convention is just an AGREEMENT on how to name things. Things will still work even if we don't use the proper naming
	// Classes, Functions and Properties -> PascalCase
	// variables and parameters -> camelCase
	// interfaces names -> ALWAYS start with I ( Example: IUserRepository )
	// private fields -> _camelCaseName ( Example: _mapper )
	// generic types -> always named T ( If there are more then T1, T2, T3 )

	public class ReminderService : IReminderService
	{
		private readonly IMapper _mapper;
		private readonly IReminderRepository _reminderRepository;

		public ReminderService(IMapper mapper, IReminderRepository reminderRepository)
		{
			_mapper = mapper;
			_reminderRepository = reminderRepository;
		}

		public List<ReminderDTO> GetAll(int userId)
		{
			return _mapper.Map<List<ReminderDTO>>(_reminderRepository.GetAll(userId));
		}

		public bool Insert(ReminderDTO reminder)
		{
			var result = _reminderRepository.Insert(_mapper.Map<Reminder>(reminder));
			if (result == 1) return true;
			return false;
		}

		public bool Delete(int reminderId)
		{
			var result = _reminderRepository.Delete(reminderId);
			if (result == 1) return true;
			return false;
		}

		public ReminderDTO GetById(int reminderId)
		{
			return _mapper.Map<ReminderDTO>(_reminderRepository.GetById(reminderId));
		}
	}
}