using NUnit.Framework;
using PetStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests
{
	public class AuthenticationTests
	{
        [Test]
        public void GenerateToken_WhenProvidedValidDate_TokenIsReturned()
        {
            // Arrange
            var dateTime = new DateTime(2021, 01, 01);
            var expected = "AICsLuit2AgAAAAAAAAAAAAAAAAAAAAA";
            var key = Guid.Empty;
            var sut = new AuthenticationService();

            // Act
            var actual = sut.GenerateToken(dateTime, key);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckToken_WhenProvidedValidDate_TokenIsReturned()
        {
            // Arrange
            var token = "AICsLuit2AiWMY07mb/pRIvqVobN4cMA";
            var daysValid = 9999;
            var sut = new AuthenticationService();

            // Act
            var actual = sut.CheckToken(token, daysValid);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
