using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	public class Generics
	{
		// We write <T> next to the name of the method, to make it generic
		// After that we can use T as a type inside the whole method including the paramters
		// The generic method must get the type when it is called. For now the type is unknown
		public void GetInfo<T>(List<T> items)
		{
			T first = items[0];
			Console.WriteLine($"This list has {items.Count} items and they are of type {first.GetType().Name}");
		}


		public void Execute()
		{
			List<int> ints = new List<int>() { 1, 2, 5, 6, 9 };
			List<string> strings = new List<string>() { "Bob", "Jill", "Greg" };
			List<bool> bools = new List<bool>() { true, false };

			GetInfo<int>(ints);
			GetInfo<string>(strings);
			// This is an invalid example since we are passing bool as T and we defined T to be int
			// GetInfo<int>(bools);

			GetInfo(ints);
			GetInfo(strings);
		}
	}

	public class GenericClass<T>
	{
		public void GetInfo(List<T> items)
		{
			T first = items[0];
			Console.WriteLine($"This list has {items.Count} items and they are of type {first.GetType().Name}");
		}


		public void Execute(List<T> items)
		{
			GetInfo(items);
		}
	}
}
