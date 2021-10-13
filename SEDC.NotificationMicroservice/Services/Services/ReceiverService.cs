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
	public class ReceiverService : IReceiverService
	{
		private readonly IRepository<Notification> _notificationRepository;

		public ReceiverService(IRepository<Notification> notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}
		public void ReceiveNotification(NotificationDto notification)
		{
			_notificationRepository.Insert(notification.Map());
		}

		public void UpdateNotificationSentStatus(List<NotificationDto> notifications)
		{
			// We find all the ids from the DTO notifications
			var ids = notifications.Select(x => x.Id);
			// We find all entities in the DB that have an ID matching the ids we got from the DTOs
			var entities = _notificationRepository.GetAll(x => ids.Any(id => id == x.Id));

			// We change the IsSent property to all entities we found to be matching to ids, to true
			// This will change the logic to suggest that all of these notifications are already sent
			entities.ToList().ForEach(x => {
				x.IsSent = true;
				x.DateSent = DateTime.Now;
				});
			// We update the DB with the changes we made
			_notificationRepository.Update(entities);
		}
	}
}
