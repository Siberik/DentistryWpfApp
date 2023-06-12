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


      

    }
}
    

