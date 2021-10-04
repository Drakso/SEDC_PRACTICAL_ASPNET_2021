using Application;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class RemindersController : Controller
	{
		private readonly IReminderService _reminderService;
		private readonly IMapper _mapper;

		public RemindersController(IReminderService reminderService, IMapper mapper)
		{
			_reminderService = reminderService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var reminders = _mapper.Map<List<ReminderViewModel>>(_reminderService.GetAll());

			return View(new RemindersHomeViewModel() { Reminders = reminders });
		}

		[HttpGet]
		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Insert(ReminderViewModel reminder)
		{
			var newReminder = _mapper.Map<ReminderDTO>(reminder);
			newReminder.UserId = 3;
			_reminderService.Insert(newReminder);

			return RedirectToAction("Index", "Reminders");
		}
	}
}
