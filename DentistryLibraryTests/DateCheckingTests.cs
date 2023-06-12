using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistryClassLibrary
{
    [TestClass]
    public class DateCheckingTests
    {
        /// <summary>
        /// Тестирование ввода пустой строки.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_EmptyString_ReturnsFalse()
        {
            // Arrange
            string input = "";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с пробелом.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithSpace_ReturnsFalse()
        {
            // Arrange
            string input = " ";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с буквами.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithLetters_ReturnsFalse()
        {
            // Arrange
            string input = "abc";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с цифрами.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithDigits_ReturnsFalse()
        {
            // Arrange
            string input = "12345";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с комбинацией цифр и букв.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithDigitsAndLetters_ReturnsFalse()
        {
            // Arrange
            string input = "123abc";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с специальными символами.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            string input = "!@#$%";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с датой в формате "dd.MM.yyyy".
        /// Ожидается, что метод вернет true.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithValidDateFormat_ReturnsTrue()
        {
            // Arrange
            string input = "31.12.2022";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тестирование ввода строки с датой в некорректном формате.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithInvalidDateFormat_ReturnsTrue()
        {
            // Arrange
            string input = "2022-12-31";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тестирование ввода строки с некорректной датой.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithInvalidDate_ReturnsFalse()
        {
            // Arrange
            string input = "31.13.2022";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода строки с корректной датой и временем.
        /// Ожидается, что метод вернет true.
        /// </summary>
        [TestMethod]
        public void DataChecking_StringWithValidDateTime_ReturnsTrue()
        {
            // Arrange
            string input = "31.12.2022 12:34:56";

            // Act
            bool result = HourCheckingTests.DataChecking(input);

            // Assert
            Assert.IsTrue(result);
        }
    }

}

