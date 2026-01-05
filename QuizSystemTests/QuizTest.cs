using QuizSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystemTests
{
    [TestClass]
    public class QuizTests
    {
        [TestMethod]
        public void Quiz_Constructor_InitializesProperties()
        {
            // Arrange
            int id = 1;
            string title = "OOP Fundamentals";
            string desc = "Covers basics of object-oriented programming";
            Category cat = new Category(1, "Programming", "Concepts");
            List<Question> questions = new List<Question>();

            // Act
            var quiz = new Quiz(id, title, desc, new DateTime(2025, 09, 01), questions, cat);

            // Assert
            Assert.AreEqual("OOP Fundamentals", quiz.QuizTitle);
            Assert.AreEqual(new DateTime(2025, 09, 01), quiz.QuizDate);
        }
    }
}
