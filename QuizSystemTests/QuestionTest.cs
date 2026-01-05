using QuizSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystemTests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void Question_Constructor_StoreDataCorrectly()
        {
            // Arrange
            int qId = 1;
            string text = "What does OOP stand for?";
            string correct = "Object-Oriented Programming";
            string diff = "Easy";

            List<string> options = new List<string>
        {
            "Object-Oriented Programming",
            "Operational Output Processing",
            "Open Order Protocol",
            "Overloaded Operator Procedure"
        };

            // Act
            var question = new Question(qId, text, options, correct, diff);

            // Assert
            Assert.AreEqual(text, question.QuestionText);
            Assert.AreEqual(correct, question.QuestionCorrectAnswer);
            Assert.AreEqual(diff, question.QuestionDifficultyLevel);

            // Verify options are stored correctly
            Assert.AreEqual(4, question.QuestionOptions.Count);
            Assert.AreEqual("Open Order Protocol", question.QuestionOptions[2]);
        }

        [TestMethod]
        public void Question_EmptyText_StoredEmpty()
        {
            // Edge case test
            // Arrange
            string emptyText = "";

            // Act
            var question = new Question(1, emptyText, new List<string>(), "Ans", "Easy");

            // Assert
            Assert.AreEqual(string.Empty, question.QuestionText);
        }
    }
}