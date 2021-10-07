using DataAccess.Domain;
using DataAccess.Repository;
using Services.Helpers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
	public class SenderService : ISenderService
	{
		private readonly IRepository<Notification> _notificationRepository;

		public SenderService(IRepository<Notification> notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}
		public List<NotificationDto> SendAllUnsentNotifications()
		{
			var notifications = _notificationRepository.GetAll(x => x.IsSent == false);

			return notifications.Map().ToList();
		}
	}
}
