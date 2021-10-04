using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
	public static class PriorityUtils
	{
		private static Dictionary<Priority, string> PriorityColorMap = new Dictionary<Priority, string>()
		{
			{Priority.High, "Red"},
			{Priority.Medium, "Yellow"},
			{Priority.Low, "Green"},
			{Priority.Undefined, "Blue"}
		};

		public static string GetName(this Priority priority) => Enum.GetName(typeof(Priority), priority);

		public static string GetColor(this Priority priority) => PriorityColorMap[priority];
	}
}
