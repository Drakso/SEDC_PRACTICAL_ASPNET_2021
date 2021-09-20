using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Specification
// 1. Can sum and subtract 2 numbers
// 2. Can sum and subtract 2 numbers as strings
// 3. Can sum and subtract any numbers in a list
// 4. There should be a limit to the numbers ( 1000000 )
// 5. No negative numbers allowed

namespace CalculatorService.Services
{
	// Our implementation ( The business logic of our project )
	public class Calculator
	{
		private readonly int Range = 1000000;

		public int Sum(int number1, int number2)
		{
			var numbers = new List<int>() { number1, number2 };
			CheckIfNumberIsInRange(numbers);
			CheckIfNumberIsNegative(numbers);

			return number1 + number2;
		}

		public int SumWithStrings(string number1, string number2)
		{
			var convertedNumber1 = ConvertStringToInt(number1);
			var convertedNumber2 = ConvertStringToInt(number2);


			var numbers = new List<int>() { convertedNumber1, convertedNumber2 };
			CheckIfNumberIsInRange(numbers);
			CheckIfNumberIsNegative(numbers);

			return convertedNumber1 + convertedNumber2;
		}

		public int SumWithList(List<int> numbers)
		{
			CheckIfNumberIsInRange(numbers);
			CheckIfNumberIsNegative(numbers);

			var sum = 0;
			foreach (var number in numbers)
			{
				sum = sum + number;
			}
			return sum;
		}

		private void CheckIfNumberIsInRange(List<int> numbers)
		{
			foreach (var number in numbers)
			{
				if (number > Range) throw new Exception($"You can't enter numbers over the {Range} range.");
			}
			
		}

		private void CheckIfNumberIsNegative(List<int> numbers)
		{
			foreach (var number in numbers)
			{
				if (number < 0) throw new Exception("You can't enter a negative number.");
			}
		}

		private int ConvertStringToInt(string strNumber)
		{
			var isConverted = int.TryParse(strNumber, out var result);
			if (isConverted) return result;
			throw new Exception("Convert failed. You must enter a valid number!");
		}
	}
}
