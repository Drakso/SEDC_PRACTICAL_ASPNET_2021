using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	public class Events
	{
		public delegate void SayHello(string name);
		public event SayHello SayHelloHandler;

		public void SayHelloViaEmail(string name)
		{
			Console.WriteLine($"Hello there {name}!");
			Console.WriteLine("This message was sent via Email.");
			// Imagine that some code that sends an email is written here
		}

		public void SayHelloViaSMS(string name)
		{
			Console.WriteLine($"Hello there {name}!");
			Console.WriteLine("This message was sent via SMS.");
			// Imagine that some code that sends an SMS is written here
		}

		public void SayHelloViaPushNotification(string name)
		{
			Console.WriteLine($"Hello there {name}!");
			Console.WriteLine("This message was sent via Push Notification.");
			// Imagine that some code that sends an push notification is written here
		}

		public void Execute()
		{
			// Someone decides to say hello to bob via SMS, PushNotification and Email
			// We add the corresponding functions that will do the sending in the Event
			// This will not execute the functions. It will just store them in the event
			SayHelloHandler += SayHelloViaEmail;
			SayHelloHandler += SayHelloViaSMS;
			SayHelloHandler += SayHelloViaPushNotification;

			// The event now is executed ( This can be done when something happens, like a click, like a some information coming through etc. )

			SayHelloHandler("Bob");

			// Someone decides that saying hello is costly and removes the notification for sending hello via sms
			SayHelloHandler -= SayHelloViaSMS;

			SayHelloHandler("Greg");
		}
	}
}
