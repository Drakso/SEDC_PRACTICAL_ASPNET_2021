using CalculatorService.Utils;
using CalculatorService.Validators;
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

		// Controller:
		// new Calculator(<PROVIDE VALIDATOR AND UTILITIES HERE>)

		private IValidator _validator;
		private IUtilities _utilities;

		public Calculator(IValidator validator, IUtilities utilities)
		{
			// We decide to resolve ( create ) the dependencies
			// This creates tight coupling. We must change these every time we change the implementation of them as well
			//_validator = new Validator();
			//_utilities = new Utilities();

			_validator = validator;
			_utilities = utilities;
		}

		public int Sum(int number1, int number2)
		{
			var numbers = new List<int>() { number1, number2 };
			_validator.CheckIfNumberIsInRange(numbers);
			_validator.CheckIfNumberIsNegative(numbers);

			return number1 + number2;
		}

		public int Sum(string number1, string number2)
		{
			var convertedNumber1 = _utilities.ConvertStringToInt(number1);
			var convertedNumber2 = _utilities.ConvertStringToInt(number2);


			var numbers = new List<int>() { convertedNumber1, convertedNumber2 };
			_validator.CheckIfNumberIsInRange(numbers);
			_validator.CheckIfNumberIsNegative(numbers);

			return convertedNumber1 + convertedNumber2;
		}

		public int Sum(List<int> numbers)
		{
			_validator.CheckIfNumberIsInRange(numbers);
			_validator.CheckIfNumberIsNegative(numbers);

			var sum = 0;
			foreach (var number in numbers)
			{
				sum = sum + number;
			}
			return sum;
		}
	}
}
