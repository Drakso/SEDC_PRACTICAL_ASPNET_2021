using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	public class Delegates
	{
		// Defining a delegate
		// This is a method type that will only accept methods that accept 1 string and return void ( nothing )
		public delegate void SayDelegate(string message);

		public void SayThanks(string name)
		{
			Console.WriteLine($"Thanks a lot {name}!");
		}

		public void MeetPeople(string person1, string person2) 
		{
			Console.WriteLine($"{person1} and {person2} just met!");
		}

		// Higherorder function that accepts methods that have the same signature as SayDelegate
		public void SayAnything(SayDelegate sayMethod, string name)
		{
			sayMethod(name);
		}

		public void Execute()
		{
			// We are creating a variable that will store a function of type SayDelegate
			// We add a function by the delegate (string name) signature and we add implementation
			SayDelegate sayHello = delegate (string name)
			{
				Console.WriteLine($"Hello there {name}!");
			};

			// When we call this variable as method, it executes the method that we provided
			sayHello("Bob");

			// Example with arrow function ( Practically the same example, different syntax )
			SayDelegate sayBye = (string name) => Console.WriteLine($"Bye {name}!");

			sayBye("Greg");

			// Example of storing an already existing method in to a variable of type delegate
			SayDelegate sayThanks = SayThanks;

			sayThanks("Jill");

			// This is an invalid scenario because we are not sending a function that has the same signature as the delegate
			// SayDelegate meetPeople = MeetPeople("Bob", "Jill");

			// Calling Higherorder function
			SayAnything(sayHello, "Bob");
			SayAnything(sayBye, "Greg");
			SayAnything(sayThanks, "Jill");
			SayAnything(x => Console.WriteLine($"Go AWAY {x}!"), "Bill");
		}
	}
}
