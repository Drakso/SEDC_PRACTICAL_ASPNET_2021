using NSubstitute;
using NUnit.Framework;
using PetStore.API.Data;
using PetStore.API.Models;
using PetStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests
{
	public class UsersTests
	{
		private IAuthenticationService _authService;

		[SetUp]
		public void SetUp()
		{
			_authService = Substitute.For<IAuthenticationService>();
		}

		[Test]
		public void Register_WhenNonExistingUsernameAndValidPasswordAreProvided_ShouldReturnToken()
		{
			// Arrange
			var username = "bob99";
			var password = "bob123";
			var expected = "valid-token";
			_authService.GenerateToken(Arg.Any<DateTime>(), Arg.Any<Guid>()).Returns(expected);
			var sut = new UserService(_authService);

			// Act
			var actual = sut.Register(username, password);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Register_WhenExistingUsernameIsProvided_ShouldThrowException()
		{
			// Arrange
			var username = "bob99";
			var password = "bob123";
			var sut = new UserService(_authService);
			var expectedMessage = "User already exists!";
			var expectedException = new Exception(expectedMessage);
			Db.Users.Add(new User() { Username = username, Password = password });

			// Act
			TestDelegate act = () => sut.Register(username, password);

			// Assert
			var ex = Assert.Throws<Exception>(act);
			Assert.AreEqual(expectedMessage, ex.Message);
		}

		[Test]
		public void LogIn_WhenValidUsernameAndPasswordAreProided_ShouldReturnToken()
		{
			// Arrange
			var username = "bob99";
			var password = "bob123";
			var expected = "valid-token";
			_authService.GenerateToken(Arg.Any<DateTime>(), Arg.Any<Guid>()).Returns(expected);
			var sut = new UserService(_authService);
			Db.Users.Add(new User() { Username = username, Password = password });

			// Act
			var actual = sut.LogIn(username, password);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void LogIn_WhenInvalidUsernameAndPasswordAreProvided_ShouldThrowException()
		{
			// Arrange
			var username = "jill22";
			var password = "jillbest";
			var sut = new UserService(_authService);
			var expectedMessage = "Log in failed!";
			var expectedException = new Exception(expectedMessage);

			// Act
			TestDelegate act = () => sut.LogIn(username, password);

			// Assert
			var ex = Assert.Throws<Exception>(act);
			Assert.AreEqual(expectedMessage, ex.Message);
		}

		[TearDown]
		public void Dispose()
		{
			// We clear the DB of test data
			// We are assuming here that we have a speical DB for testing
			// Don't do this on a real database
			// IF you want to use test DB in your tests, and are using Entity Framework, you can use EntityFrameworkCore.InMemory
			Db.Users = new List<User>();
		}
	}
}
