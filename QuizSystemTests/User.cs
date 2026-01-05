using QuizSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystemTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Login_CorrectCredentials_ReturnsTrue()
        {
            // Arrange
            var user = new User(1, "testuser", "password123", UserRole.User, "contact@test.com", false);

            // Act
            bool result = user.Login("testuser", "password123");

            // Assert
            Assert.IsTrue(result, "Login should return true for correct credentials");
            Assert.IsTrue(user.IsLoggedIn, "IsLoggedIn property should be set to true");
        }

        [TestMethod]
        public void Login_IncorrectPassword_ReturnsFalse()
        {
            // Arrange
            var user = new User(1, "testuser", "password123", UserRole.User, "contact@test.com", false);

            // Act
            bool result = user.Login("testuser", "wrongpassword");

            // Assert
            Assert.IsFalse(result, "Login should return false for wrong password");
            Assert.IsFalse(user.IsLoggedIn, "IsLoggedIn property should remain false");
        }
    }
}
