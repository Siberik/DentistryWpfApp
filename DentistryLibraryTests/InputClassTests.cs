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
    public class InputClassTests
    {
        /// <summary>
        /// Тестирование ввода корректного времени с ведущими нулями.
        /// Ожидается, что метод вернет true.
        /// </summary>
        [TestMethod]
        public void HourChecking_ValidTimeWithLeadingZeros_ReturnsTrue()
        {
            // Arrange
            string input = "08:15";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тестирование ввода некорректного времени с отрицательным часом.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_InvalidTimeWithNegativeHour_ReturnsFalse()
        {
            // Arrange
            string input = "-10:30";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода некорректного времени с нулевым часом и ненулевыми минутами.
        /// Ожидается, что метод вернет true.
        /// </summary>
        [TestMethod]
        public void HourChecking_InvalidTimeWithZeroHourAndNonZeroMinutes_ReturnsTrue()
        {
            // Arrange
            string input = "00:30";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тестирование ввода некорректного времени с некорректными минутами.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_InvalidTimeWithInvalidMinutes_ReturnsFalse()
        {
            // Arrange
            string input = "10:75";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода некорректного времени с некорректными часами.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_InvalidTimeWithInvalidHours_ReturnsFalse()
        {
            // Arrange
            string input = "25:30";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Тестирование ввода некорректного времени без разделителя ":".
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_InvalidTime_ReturnsFalse()
        {
            // Arrange
            string input = "2530";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода некорректного времени с буквами.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_InvalidTimeWithLetters_ReturnsFalse()
        {
            // Arrange
            string input = "25t30";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Тестирование ввода некорректного времени. Ввод только букв.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_OnlyLetters_ReturnsFalse()
        {
            // Arrange
            string input = "iuygfcdujisjikhiugdsfhguikgh";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Тестирование ввода некорректного времени. Пустая строка.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_StringEmpty_ReturnsFalse()
        {
            // Arrange
            string input = "";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Тестирование ввода некорректного времени. Только пробел.
        /// Ожидается, что метод вернет false.
        /// </summary>
        [TestMethod]
        public void HourChecking_Space_ReturnsFalse()
        {
            // Arrange
            string input = " ";

            // Act
            bool result = InputClass.HourChecking(input);

            // Assert
            Assert.IsFalse(result);
        }

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

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
            bool result = InputClass.DataChecking(input);

            // Assert
            Assert.IsTrue(result);
        }
    }

}
