using DentistryClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistryLibraryTests
{
    [TestClass]
    public class PasswordGeneratorClassTests
    {
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
