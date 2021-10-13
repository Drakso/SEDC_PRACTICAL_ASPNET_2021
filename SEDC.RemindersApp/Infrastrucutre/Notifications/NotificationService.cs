using Application.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Infrastrucutre.Notifications
{
	public class NotificationService : INotificationService
	{
		private readonly AppSettings _options;
		private readonly IHttpClientFactory _clientFactory;
		public NotificationService(IOptions<AppSettings> options, IHttpClientFactory clientFactory)
		{
			_options = options.Value;
			_clientFactory = clientFactory;
		}
		public void SendNotification(Notification notification)
		{
			var client = _clientFactory.CreateClient();
			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", _options.Token);
			// Serializastion converts from complex to simpler type ( In our case from C# object to JSON stirng object )
			var jsonData = JsonConvert.SerializeObject(notification);
			var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var url = _options.NotificationApiUrl + "Add";


			var result = client.PostAsync(url, data);

			if (!result.Result.IsSuccessStatusCode)
			{
				throw new Exception("Request to Notification API was not successfull");
			}
		}
	}
}
