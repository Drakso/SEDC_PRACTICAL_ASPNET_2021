using System;
using System.Collections.Generic;

namespace Examples
{
	class Program
	{
		private static readonly Delegates _delegates = new Delegates();
		private static readonly Events _events = new Events();
		private static readonly Generics _generics = new Generics();
		private static readonly GenericClass<int> _genericClassInts = new GenericClass<int>();
		private static readonly GenericClass<string> _genericClassStrings = new GenericClass<string>();
		private static readonly ScopedGenerics _scopedGenerics = new ScopedGenerics();

		static void Main(string[] args)
		{
			Console.WriteLine("-------------DELEGATES----------------");
			_delegates.Execute();
			Console.WriteLine("-------------EVENTS----------------");
			_events.Execute();
			Console.WriteLine("-------------GENERICS----------------");
			_generics.Execute();
			Console.WriteLine("-------------GENERIC CLASS----------------");
			_genericClassInts.Execute(new List<int>() { 1, 2, 5, 6, 9 });
			_genericClassStrings.Execute(new List<string>() { "Bob", "Jill", "Greg" });
			Console.WriteLine("-------------SCOPED GENERICS----------------");
			_scopedGenerics.Execute();
			Console.WriteLine("-------------EXTENSION METHODS----------------");
			ExtensionClass.Execute();

			Console.ReadLine();
		}
	}
}
