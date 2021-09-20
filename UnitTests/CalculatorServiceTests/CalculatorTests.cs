using CalculatorService.Services;
using CalculatorServiceTests.CustomMocks;
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
		private Calculator _sut;
        private IUtilitiesMock _utilities;
        private IValidatorMock _validator;

        [SetUp]
        public void SetUp()
        {
            _utilities = new UtilitiesMock();
            _validator = new ValidatorMock();
        }
        public void SetUpUtilities(List<int> results, Action? expression)
        {
            if (expression != null) _utilities.Executes(expression);
            if (results != null) results.ForEach(x => _utilities.Returns(x));
        }

        public void SetUpValidator(Action? expression)
        {
            if (expression != null) _validator.Executes(expression);
        }

        public void SetUpCalculator()
        {
            _sut = new Calculator(_validator, _utilities);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(100, 5, 105)]
        [TestCase(0, 6, 6)]
        public void Sum_WhenTwoValidNumbersAreProvided_SumOfNumbersIsReturned(int number1, int number2, int expected)
        {
            // Arrange
            SetUpUtilities(null, null);
            SetUpValidator(null);
            SetUpCalculator();

            // Act
            var actual = _sut.Sum(number1, number2);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        // This attribute represents a test and is mandatory
        [Test]
        public void Sum_WhenTwoOutOfRangeNumbersAreProvided_InvalidNumberExceptionIsThrown()
        {
            // JS var assings value without type ( on compile, var will still be var )
            // In js we can change variable type any time
            // Ex: var x = 5; -> compile -> var x = 5;
            // C# var is just a placeholder until compile ( on compile, var becomes the type of the value )
            // In C# we can't change variable type any time ( on runtime for example )
            // Ex: var x = 5; -> compile -> Int32 x = 5;
            // Arrange
            var number1 = 5;
            var number2 = 123456789;

            Action throwException = () => throw new Exception("Number out of range");
            SetUpUtilities(null, null);
            SetUpValidator(throwException);
            SetUpCalculator();

            // Act
            // Assert
            // Delegate is just a type that represents a function
            // We can put functions in variables in C#
            // In order to tell C# what type is our variable, we must use delegate
            // TestDelegate is just a normal delegate but implemented in NUnit so we can keep methods in variables for testing
            TestDelegate act = () => _sut.Sum(number1, number2);
            Assert.Throws<Exception>(act);
        }

        [Test]
        public void Sum_WhenTwoNegativeNumbersAreProvided_InvalidNumberExceptionIsThrown()
        {
            // Arrange
            var number1 = -1;
            var number2 = -500;
            var numbers = new List<int>() { number1, number2 };
            var expectedMessage = "Calculator does not accept negative values!";

            Action throwException = () => throw new Exception(expectedMessage);
            SetUpUtilities(null, null);
            SetUpValidator(throwException);
            SetUpCalculator();

            // Act
            TestDelegate act = () => _sut.Sum(number1, number2);

            // We put methods that we expect to throw an exceptuion in variables
            // If we don't and just call the method, the exception will be thrown inside the test and will fail the test right away

            // Assert
            var ex = Assert.Throws<Exception>(act);
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(100, 5, 105)]
        [TestCase(0, 6, 6)]
        public void Sum_WhenTwoValidStringNumbersAreProvided_SumOfNumbersIsReturned(int number1, int number2, int expected)
        {

            // Arrange
            var number1str = number1.ToString();
            var number2str = number2.ToString();

            SetUpUtilities(new List<int>() { number1, number2 }, null);
            SetUpValidator(null);
            SetUpCalculator();

            // Act
            var actual = _sut.Sum(number1str, number2str);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Sum_WhenTwoOutOfRangeStringNumbersAreProvided_InvalidNumberExceptionIsThrown()
        {
            // Arrange
            var number1 = 5;
            var number2 = 123456789;
            var number1str = number1.ToString();
            var number2str = number2.ToString();

            Action throwException = () => throw new Exception("Number out of range");
            SetUpUtilities(new List<int>() { number1, number2 }, null);
            SetUpValidator(throwException);
            SetUpCalculator();

            // Act
            TestDelegate act = () => _sut.Sum(number1str, number2str);

            // Assert
            Assert.Throws<Exception>(act);
        }

        [Test]
        public void Sum_WhenTwoInvalidStringNumbersAreProvided_NumberConversionFailedIsThrown()
        {
            // Arrange
            var number1 = "invalid";
            var number2 = "12";

            Action throwException = () => throw new Exception("Number out of range");
            SetUpUtilities(null, throwException);
            SetUpValidator(null);
            SetUpCalculator();

            // Act
            TestDelegate act = () => _sut.Sum(number1, number2);

            // Assert
            Assert.Throws<Exception>(act);
        }

        [Test]
        public void Sum_WhenListOfValidNumbersIsProvided_SumOfAllNumbersIsReturned()
        {
            // Arrange
            var numbers = new List<int>() { 1, 4, 6, 9, 100 };
            var expected = 120;

            SetUpUtilities(null, null);
            SetUpValidator(null);
            SetUpCalculator();

            // Act
            var actual = _sut.Sum(numbers);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
