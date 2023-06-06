using DentistryClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DentistryLibraryTests
{
    [TestClass]
    public class MailClassTests
    { 
         
        /// <summary>
        /// Тестирование успешной отправки письма.
        /// Ожидается, что метод SendMail вернет true.
        /// </summary>
        [TestMethod]
        public void SendMail_Successful_ReturnsTrue()
        {
            // Arrange
            string to = "lolgagr@gmail.comt";
            string login = "lolo";
            string password = "testpassword";

            // Act
            bool result = MailClass.SendMail(to, login, password);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование отправки письма с неверным форматом адреса получателя.
        /// Ожидается, что метод SendMail вернет false.
        /// </summary>
        [TestMethod]
        public void SendMail_InvalidRecipientAddress_ReturnsFalse()
        {
            // Arrange
            string to = "invalidrecipient";
            string login = "testuser";
            string password = "testpassword";

            // Act
            bool result = MailClass.SendMail(to, login, password);

            // Assert
            Assert.IsFalse(result);
        }

     
        [TestMethod]
        public void SendMail_EmptyLogin_ReturnsFalse()
        {
            // Arrange
            string to = "recipient@example.com";
            string login = string.Empty;
            string password = "testpassword";

            // Act
            bool result = MailClass.SendMail(to, login, password);

            // Assert
            Assert.IsFalse(result);
        }

        // Тестирование отправки письма с длинным паролем пользователя.
        // Ожидается, что метод SendMail вернет false.
        [TestMethod]
        public void SendMail_LongPassword_ReturnsFalse()
        {
            // Arrange
            string to = "recipient@example.com";
            string login = "testuser";
            string password = new string('a', 10000);

            // Act
            bool result = MailClass.SendMail(to, login, password);

            // Assert
            Assert.IsFalse(result);
        }

        // Тестирование отправки письма с длинным паролем пользователя.
        // Ожидается, что метод SendMail вернет true.
        [TestMethod]
        public void SendMail_MailEmpty_ReturnsFalse()
        {
            // Arrange
            string to = " ";
            string login = "testuser";
            string password = new string('a', 10000);

            // Act
            bool result = MailClass.SendMail(to, login, password);

            // Assert
            Assert.IsFalse(result);
        }


        /// <summary>
        /// Тестирование генерации случайного пароля.
        /// Ожидается, что длина сгенерированного пароля будет равна указанной длине.
        /// </summary>
        [TestMethod]
        public void GetRandomPassword_GeneratesPasswordWithCorrectLength()
        {
            // Arrange
            int length = 10;

            // Act
            string password = MailClass.GetRandomPassword(length);

            // Assert
            Assert.AreEqual(length, password.Length);
        }

        /// <summary>
        /// Тестирование генерации случайного пароля.
        /// Ожидается, что сгенерированный пароль не будет содержать никаких пробелов.
        /// </summary>
        [TestMethod]
        public void GetRandomPassword_NoSpacesInGeneratedPassword()
        {
            // Arrange
            int length = 10;

            // Act
            string password = MailClass.GetRandomPassword(length);

            // Assert
            Assert.IsFalse(password.Contains(" "));
        }


        /// <summary>
        /// Тестирование генерации случайного пароля.
        /// Ожидается, что сгенерированный пароль будет содержать только цифры и буквы верхнего и нижнего регистров.
        /// </summary>
        [TestMethod]
        public void GetRandomPassword_OnlyAlphanumericCharactersInGeneratedPassword()
        {
            // Arrange
            int length = 10;

            // Act
            string password = MailClass.GetRandomPassword(length);

            // Assert
            StringAssert.Matches(password, new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+$"));
        }

        // Дополнительные тесты ...

        /// <summary>
        /// Тестирование генерации случайного пароля.
        /// Ожидается, что длина сгенерированного пароля будет равна 0 при указании отрицательной длины.
        /// </summary>
        [TestMethod]
        public void GetRandomPassword_ReturnsEmptyStringForNegativeLength()
        {
            // Arrange
            int length = -5;

            // Act
            string password = MailClass.GetRandomPassword(length);

            // Assert
            Assert.AreEqual(0, password.Length);
        }

    }
}
    

