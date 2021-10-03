using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	public class ScopedGenerics
	{
		public void PrintAll<T>(List<T> items) where T : BaseEntity
		{
			foreach (T item in items)
			{
				Console.WriteLine(item.GetInfo());
			}
		}

		public void Execute()
		{
			var orders = new List<Order>()
			{
				new Order() { Id = 1, Address = "First St", Reciever = "Bob" },
				new Order() { Id = 2, Address = "Second St", Reciever = "Jill" }
			};

			var products = new List<Product>()
			{
				new Product() { Id = 1, Title = "Potato", Description = "Best food source" },
				new Product() { Id = 2, Title = "Pet Rock", Description = "Best friend that lives forever" }
			};

			PrintAll<Order>(orders);
			PrintAll<Product>(products);
		}

	}

	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public abstract string GetInfo();
	}

	public class Order : BaseEntity
	{
		public string Reciever { get; set; }
		public string Address { get; set; }

		public override string GetInfo()
		{
			return $"{Id}) {Reciever} on address: {Address}";
		}
	}

	public class Product : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public override string GetInfo()
		{
			return $"{Id}) {Title} - {Description}";
		}
	}
}
