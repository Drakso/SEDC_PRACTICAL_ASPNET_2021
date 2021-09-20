using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Validators
{
	public class Validator : IValidator
	{
		private readonly int Range = 1000000;
		private bool IsOutOfRange(int number) => number > Range;
		private bool IsNegative(int number) => number < 0;

		public void CheckIfNumberIsInRange(List<int> numbers)
		{
			// You can use any of these approaches to implement this logic. They all do the job well.
			//if (numbers.Any(x => x > Range)) throw new Exception($"You can't enter numbers over the {Range} range.");

			//foreach (var number in numbers)
			//{
			//	if (IsOutOfRange(number)) throw new Exception($"You can't enter numbers over the {Range} range.");
			//}

			if (numbers.Any(IsOutOfRange)) throw new Exception($"You can't enter numbers over the {Range} range.");
		}

		public void CheckIfNumberIsNegative(List<int> numbers)
		{
			if (numbers.Any(IsNegative)) throw new Exception("You can't enter a negative number.");
		}
	}
}
