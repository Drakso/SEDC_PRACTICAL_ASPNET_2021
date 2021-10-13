using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Configuration;
using Services.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Notifications.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly IReceiverService _receiverService;
		private readonly ISenderService _senderService;
		private readonly AppSettings _options;

		public NotificationsController(IReceiverService receiverService, ISenderService senderService, IOptions<AppSettings> options)
		{
			_receiverService = receiverService;
			_senderService = senderService;
			_options = options.Value;
		}

		[Authorize]
		[HttpPost("/Add")]
		public IActionResult Add(NotificationDto notification)
		{
			try
			{
				AuthorizeRemindersApp();
				_receiverService.ReceiveNotification(notification);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("/Get")]
		public IActionResult GetNotSent()
		{
			try
			{
				AuthorizeRemindersApp();
				var notifications = _senderService.SendAllUnsentNotifications();
				return Ok(notifications);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("/Send")]
		public IActionResult UpdateNotifications([FromBody] List<NotificationDto> notifications)
		{
			try
			{
				AuthorizeRemindersApp();
				_receiverService.UpdateNotificationSentStatus(notifications);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private void AuthorizeRemindersApp()
		{
			if (User.FindFirst(ClaimTypes.Name).Value != _options.RemindersAppName) throw new Exception("Incorrect app key!");
		} 
	}
}
