﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
	public class AppSettings
	{
		public string ConnectionString { get; set; }
		public string Secret { get; set; }
		public string NotificationApiUrl { get; set; }
		public string AppName { get; set; }
		public string Token { get; set; }
	}
}
