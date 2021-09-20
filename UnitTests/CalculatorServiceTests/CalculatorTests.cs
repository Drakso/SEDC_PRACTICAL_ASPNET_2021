using CalculatorService.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests
{
	// In NUnit 3, this attribute is optional
	// We can leave it out if we want to
	// In older versions this attribute is mandatory
	[TestFixture]
	public class CalculatorTests
	{
		//// This attribute represents a test and is mandatory
		//[Test]
		//public void Sum_WhenTwoValidIntegersAreProvided_SumOfThoseNumbersIsReturned()
		//{
		//	// Arrange
		//	var number1 = 2;
		//	var number2 = 3;
		//	var expected = 5;
		//	var sut = new Calculator();

		//	// Act
		//	var actual = sut.Sum(number1, number2);

		//	// Assert
		//	Assert.AreEqual(expected, actual); // Standard assertion
		//}

		//[Test]
		//public void Sum_WhenNumberIsTooLarge_ExceptionIsThrown()
		//{
		//	// Arrange

		//	// JS var assings value without type ( on compile, var will still be var )
		//	// In js we can change variable type any time
		//	// Ex: var x = 5; -> compile -> var x = 5;
		//	// C# var is just a placeholder until compile ( on compile, var becomes the type of the value )
		//	// In C# we can't change variable type any time ( on runtime for example )
		//	// Ex: var x = 5; -> compile -> Int32 x = 5;
		//	var number1 = 123456789;
		//	var number2 = 123456789;
		//	var errorMessage = "Specified argument was out of the range of valid values. (Parameter 'Number is too large!";
		//	var sut = new Calculator();

		//	// Delegate is just a type that represents a function
		//	// We can put functions in variables in C#
		//	// In order to tell C# what type is our variable, we must use delegate
		//	// TestDelegate is just a normal delegate but implemented in NUnit so we can keep methods in variables for testing
		//	TestDelegate act = () => sut.Sum(number1, number2);

		//	// We put methods that we expect to throw an exceptuion in variables
		//	// If we don't and just call the method, the exception will be thrown inside the test and will fail the test right away

		//	// Act
		//	// Assert
		//	var ex = Assert.Throws<ArgumentOutOfRangeException>(act);
		//	Assert.AreEqual(errorMessage, ex.Message);
		//}
	}
}
