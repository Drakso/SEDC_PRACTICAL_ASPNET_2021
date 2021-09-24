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
	// TDD - Test Driven Development
	// 1. Failing test ( Red test )
	//    - At this stage we just write the test and the behaviour expected
	// 2. Successfull test ( Green test )
	//    - At this stage we add very simple implementation
	// 3. Refactor
	//    - Changing and improving previously written code
	// 4. Repeat from 1 until satisfieds

	public class PetsTests
	{
		private PetService _sut;

		// Method that executes before every test
		[SetUp]
		public void SetUp()
		{
			// This code will run before every test
			_sut = new PetService();
		}

		[Test]
		public void Add_WhenValidPetIsProvided_ShouldReturnTrue()
		{
			// Arrange
			var pet = new Pet();
			var expected = true;

			// Act
			var actual = _sut.Add(pet);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Add_WhenNullIsProvided_ShouldReturnFalse()
		{
			// Arrange
			Pet pet = null;
			var expected = false;

			// Act
			var actual = _sut.Add(pet);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Get_WhenExistingIdIsProvided_ShouldReturnCorrespondingPet()
		{
			// Arrange
			var id = 1;
			var expected = new Pet() { Id = 1, Name = "Sparky" };
			Db.Pets.Add(expected);

			// Act
			var actual = _sut.Get(id);

			// Assert
			Assert.AreSame(expected, actual);
		}
		
		[Test]
		public void Get_WhenNonExistingIdIsProvided_ShouldThrowException()
		{
			// Arrange
			var id = 9999;
			var expectedMessage = "Id does not exist!";
			var expectedException = new Exception(expectedMessage);

			// Act
			TestDelegate act = () => _sut.Get(id);

			// Assert
			var ex = Assert.Throws<Exception>(act);
			Assert.AreEqual(expectedMessage, ex.Message);
		}


		[Test]
		public void ChangeName_WhenValidPetIdAndNameIsProvided_ShouldReturnTrue()
		{
			// Arrange
			var id = 2;
			var name = "Rex";
			var expected = true;
			Db.Pets.Add(new Pet() { Id = 2, Name = "Toto" });

			// Act
			var actual = _sut.ChangeName(id, name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ChangeName_WhenInvalidIPetIdIsProvided_ShouldThrowException()
		{
			// Arrange
			var id = 9999;
			var name = "Bobby";
			var expectedMessage = "Id does not exist!";
			var expectedException = new Exception(expectedMessage);

			// Act
			TestDelegate act = () => _sut.ChangeName(id, name);

			// Assert
			var ex = Assert.Throws<Exception>(act);
			Assert.AreEqual(expectedMessage, ex.Message);
		}

		[Test]
		public void Adopt_WhenValidPetIdIsProvided_ShouldReturnPetAndRemoveFromDb()
		{
			// Arrange
			var id = 3;
			var expected = "Zoi";
			var pet = new Pet() { Id = id, Name = expected };
			var expectedIndex = -1;
			Db.Pets.Add(pet);

			// Act
			var actual = _sut.Adopt(id);
			var actualIndex = Db.Pets.IndexOf(pet);

			// Assert
			Assert.AreSame(expected, actual);
			Assert.AreEqual(expectedIndex, actualIndex);
		}

		[Test]
		public void Adopt_WhenInvalidPetIdIsProvided_ShouldThrowException()
		{
			// Arrange
			var id = 9999;
			var expectedMessage = "Id does not exist!";
			var expectedException = new Exception(expectedMessage);

			// Act
			TestDelegate act = () => _sut.Adopt(id);

			// Assert
			var ex = Assert.Throws<Exception>(act);
			Assert.AreEqual(expectedMessage, ex.Message);
		}

		// Function that will execute after tests
		[TearDown]
		public void Dispose()
		{
			// We clear the DB of test data
			// We are assuming here that we have a speical DB for testing
			// Don't do this on a real database
			// IF you want to use test DB in your tests, and are using Entity Framework, you can use EntityFrameworkCore.InMemory
			Db.Pets = new List<Pet>();
		}
	}
}
