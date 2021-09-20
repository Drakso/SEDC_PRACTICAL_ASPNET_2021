using CalculatorService.Services;
using CalculatorService.Utils;
using CalculatorService.Validators;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests
{
	public class CalculatorNSubstituteTests
	{
		[Test]
		public void Sum_WhenTwoValidNumbersAreGiven_ReturnSumOfNumbers()
		{
			// Arrange
			var number1 = 2;
			var number2 = 3;
			var expected = 5;
			IValidator validatorMock = Substitute.For<IValidator>();
			IUtilities utilitiesMock = Substitute.For<IUtilities>();

			var sut = new Calculator(validatorMock, utilitiesMock);

			// Act
			var actual = sut.Sum(number1, number2);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Sum_WhenLargeNumberIsGiven_ThrowException()
		{
			// Arrange
			var number1 = 123456789;
			var number2 = 1;
			var numbers = new List<int>() { number1, number2 };
			var message = "You can't enter numbers over the 1000000 range.";
			var expectedException = new Exception(message);
			
			IValidator validatorMock = Substitute.For<IValidator>();
			validatorMock.When(x => x.CheckIfNumberIsInRange(Arg.Any<List<int>>())).Throw(expectedException);
			IUtilities utilitiesMock = Substitute.For<IUtilities>();
			var sut = new Calculator(validatorMock, utilitiesMock);

			// Act
			TestDelegate act = () => sut.Sum(number1, number2);

			// Assert
			var ex = Assert.Throws<Exception>(act);
			Assert.AreEqual(message, ex.Message);
		}


		[Test]
		public void Sum_WhenTwoValidStringNumbersAreGiven_ReturnSumOfNumbers()
		{
			// Arrange
			var number1 = 3;
			var number2 = 2;
			var expected = 5;
			var numbers = new List<int>() { number1, number2 };

			IValidator validatorMock = Substitute.For<IValidator>();
			IUtilities utilitiesMock = Substitute.For<IUtilities>();
			utilitiesMock.ConvertStringToInt(Arg.Any<string>()).Returns(number1, number2);

			var sut = new Calculator(validatorMock, utilitiesMock);

			// Act
			var actual = sut.Sum(number1.ToString(), number2.ToString());

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
