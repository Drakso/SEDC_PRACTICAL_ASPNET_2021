using CalculatorService.Services;
using CalculatorService.Utils;
using CalculatorService.Validators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests
{
	public class CalculatorMoqTests
	{
		// Example of a bad unit test
		// var sut = new Calculator(new Validator(), new Utilities());
		// This unit test has dependencies that can affect the function Sum() which we are testing
		// This test should only test the Sum() function logic, not Validator or Utilities or Anything else
		// To resolve this we can make MOCKs out of the dependencies

		[Test]
		public void Sum_WhenTwoValidNumbersAreGiven_ReturnSumOfNumbers()
		{
			// Arrange
			var number1 = 2;
			var number2 = 3;
			var expected = 5;
			Mock<IValidator> validatorMock = new Mock<IValidator>();
			Mock<IUtilities> utilitiesMock = new Mock<IUtilities>();

			var sut = new Calculator(validatorMock.Object, utilitiesMock.Object);

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

			Mock<IValidator> validatorMock = new Mock<IValidator>();
			validatorMock.Setup(x => x.CheckIfNumberIsInRange(numbers)).Throws(expectedException);
			Mock<IUtilities> utilitiesMock = new Mock<IUtilities>();

			var sut = new Calculator(validatorMock.Object, utilitiesMock.Object);

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

			Mock<IValidator> validatorMock = new Mock<IValidator>();
			Mock<IUtilities> utilitiesMock = new Mock<IUtilities>();
			utilitiesMock.SetupSequence(x => x.ConvertStringToInt(It.IsAny<string>()))
				.Returns(number1)
				.Returns(number2);

			var sut = new Calculator(validatorMock.Object, utilitiesMock.Object);

			// Act
			var actual = sut.Sum(number1.ToString(), number2.ToString());

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
