using QuizSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystemTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int id = 101;
            string name = "JohnDoe";
            string pass = "pass1";
            string email = "johnd@ulster.ac.uk";
            string status = "active";
            bool loggedIn = false;

            // Act
            var student = new Student(id, name, pass, email, UserRole.User, loggedIn, status);

            // Assert
            Assert.AreEqual(id, student.UserId);
            Assert.AreEqual(name, student.UserName);
            Assert.AreEqual(status, student.Status);
            Assert.IsFalse(student.IsLoggedIn);
        }
        [TestMethod]
        public void Student_Inheritance_IsUser()
        {
            // Arrange
            var student = new Student(1, "Test", "Test", "Test", UserRole.User, false, "active");
            // Assert
            Assert.IsInstanceOfType(student, typeof(User));
        }
    }
}
