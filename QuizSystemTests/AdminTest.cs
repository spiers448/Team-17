using QuizSystem;

namespace QuizSystemTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int id = 1;
            string name = "AdminUser";
            DateTime testDate = DateTime.Now;

            // Act
            var admin = new Admin(id, name, "pass123", "admin@ulster.ac.uk", UserRole.Admin, "active", testDate, true);

            // Assert
            Assert.AreEqual(id, admin.UserId);
            Assert.AreEqual(name, admin.UserName);
            Assert.AreEqual(testDate, admin.LoginDate);
        }
    }
}
