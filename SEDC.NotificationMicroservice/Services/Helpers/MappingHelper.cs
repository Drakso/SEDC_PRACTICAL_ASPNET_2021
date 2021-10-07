using DataAccess.Domain;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
	public static class MappingHelper
	{
		// NotificationDto someDto = new NotificationDto(){ ... }
		// Notification mapped = someDto.Map();
		// Because this is an extension method of NotificationDto, we can call Map on any NotificationDto object
		// Automapper does this alone, but we need to do this manually
		public static Notification Map(this NotificationDto src)
		{
			return new Notification()
			{
				Id = src.Id,
				Subject = src.Subject,
				Text = src.Text,
				Email = src.Email,
				IsSent = src.IsSent,
				DateCreated = DateTime.Now,
				DateSent = src.DateSent
			};
		}

		// To map multiple of the same entity, we can use the same Map function we added previously
		// We execute Select which creates a new list out of the results of the lambda function ( x => x.Map() )
		// In our case x is NotificationDto and every item from the list is mapped with the .Map function separately
		// All .Map results are added in a collection that is then returned back 
		public static IEnumerable<Notification> Map(this IEnumerable<NotificationDto> src)
		{
			return src.Select(x => x.Map());
		}
		public static NotificationDto Map(this Notification src)
		{
			return new NotificationDto()
			{
				Id = src.Id,
				Subject = src.Subject,
				Text = src.Text,
				Email = src.Email,
				IsSent = src.IsSent,
				DateSent = src.DateSent
			};
		}
		public static IEnumerable<NotificationDto> Map(this IEnumerable<Notification> src)
		{
			return src.Select(x => x.Map());
		}
	}
}
