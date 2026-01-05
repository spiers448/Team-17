using QuizSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystemTests
{
    [TestClass]
    public class QuizSystemTests
    {
        [TestMethod]
        public void QuizSystem_Constructor_StoresLists()
        {
            // Arrange
            var admins = new List<Admin>();
            var students = new List<Student>();
            var quizzes = new List<Quiz>();
            var cats = new List<Category>();

            // Act
            var system = new QuizSystem(admins, students, quizzes, cats);

            // Assert
            Assert.IsNotNull(system.AdminUsers);
            Assert.IsNotNull(system.StudentUsers);
            Assert.AreEqual(0, system.QuizList.Count); // Should be empty but not null
        }
    }
}
