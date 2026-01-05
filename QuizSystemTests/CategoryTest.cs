using QuizSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystemTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Category_Constructor_SetsReadOnlyId()
        {
            // Arrange
            int id = 1;
            string name = "Programming";
            string desc = "Concepts of object-oriented programming";

            // Act
            Category cat = new Category(id, name, desc);

            // Assert
            Assert.AreEqual(1, cat.CategoryID);
            Assert.AreEqual("Programming", cat.CategoryName);
        }
    }
}
