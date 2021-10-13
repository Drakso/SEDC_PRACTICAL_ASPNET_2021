using Application;
using Application.Services;
using Application.Utilities;
using AutoMapper;
using Infrastrucutre.Notifications;
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
		private readonly IAuthenticationService _authenticationService;
		private readonly IReminderService _reminderService;
		private readonly IMapper _mapper;
		private readonly INotificationService _notificationService;
		private readonly string _token = "token";

		public RemindersController(IReminderService reminderService, IMapper mapper, 
			IAuthenticationService authenticationService, INotificationService notificationService)
		{
			_reminderService = reminderService;
			_mapper = mapper;
			_authenticationService = authenticationService;
			_notificationService = notificationService;
		}

		public IActionResult Index()
		{
			var tokenFromCookie = Request.GetCookie(_token);
			var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

			if (tokenFromCookie == null || userId <= 0) return RedirectToAction("Login", "Users");

			var reminders = _mapper.Map<List<ReminderViewModel>>(_reminderService.GetAll(userId));

			return View(new RemindersHomeViewModel() { Reminders = reminders });
		}

		[HttpGet]
		public IActionResult Insert()
		{
			var tokenFromCookie = Request.GetCookie(_token);
			var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

			if (tokenFromCookie == null || userId <= 0) return RedirectToAction("Login", "Users");

			return View();
		}

		[HttpPost]
		public IActionResult Insert(ReminderViewModel reminder)
		{
			var tokenFromCookie = Request.GetCookie(_token);
			var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

			var newReminder = _mapper.Map<ReminderDTO>(reminder);
			newReminder.UserId = userId;
			_reminderService.Insert(newReminder);

			return RedirectToAction("Index", "Reminders");
		}

		[HttpPost]
		public IActionResult SendNotification([FromBody] NotificationViewModel notificationVm)
		{
			var reminder = _reminderService.GetById(notificationVm.ReminderID);
			var notification = new Notification()
			{
				Email = notificationVm.Email,
				Subject = reminder.Title,
				Text = reminder.Description
			};

			_notificationService.SendNotification(notification);
			return Ok();
		}
	}
}
