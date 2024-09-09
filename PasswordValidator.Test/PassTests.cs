using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordValidator;

namespace PasswordValidator.Tests
{
    [TestClass]
    public class PasswordValidatorTests
    {
        private readonly Pass _passwordValidator = new Pass();

        [TestMethod]
        public void TestPasswordWithNoCriteria()
        {
            string password = "abcdef";
            int score = _passwordValidator.ValidatePassword(password);
            Assert.AreEqual(1, score); // Пароль содержит только строчные буквы.
        }

        [TestMethod]
        public void TestPasswordWithDigitsOnly()
        {
            string password = "12333333333";
            int score = _passwordValidator.ValidatePassword(password);
            Assert.AreEqual(2, score); // Пароль содержит цифры и длину больше 10 символов.
        }

        [TestMethod]
        public void TestPasswordWithLowercaseOnly()
        {
            string password = "abcdefghijk1234324lmnopqrstuvwxyz";
            int score = _passwordValidator.ValidatePassword(password);
            Assert.AreEqual(3, score); // Пароль содержит строчные буквы, цифры и длину более 10 символов.
        }

        [TestMethod]
        public void TestPasswordWithUppercaseOnly()
        {
            string password = "Ab11!!";
            int score = _passwordValidator.ValidatePassword(password);
            Assert.AreEqual(4, score); // Пароль содержит заглавные буквы, строчные буквы, спец символы и цифры, но пароль меньше 10 символов.
        }

        [TestMethod]
        public void TestPasswordWithAllCriteria()
        {
            string password = "A1b2c3d4e5!";
            int score = _passwordValidator.ValidatePassword(password);
            Assert.AreEqual(5, score); // Пароль содержит цифры, строчные буквы, заглавные буквы, спецсимволы и длину более 10 символов.
        }

        [TestMethod]
        public void TestPasswordWithSpecialCharactersOnly()
        {
            string password = "хах";
            int score = _passwordValidator.ValidatePassword(password);
            Assert.AreEqual(0, score); // Пароль написан на русском.
        }
    }
}
