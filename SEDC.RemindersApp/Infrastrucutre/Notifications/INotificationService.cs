﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucutre.Notifications
{
	public interface INotificationService
	{
		void SendNotification(Notification notification);
	}
}
