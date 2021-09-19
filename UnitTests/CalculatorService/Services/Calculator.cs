using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Services
{
	// Our implementation ( The business logic of our project )
	public class Calculator
	{
		private readonly int Range = 1000000;

		public int Sum(int number1, int number2)
		{
			if (number1 > Range || number2 > Range) throw new ArgumentOutOfRangeException("");
			return number1 + number2;
		}
	}
}
