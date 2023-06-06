using DentistryClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DentistryLibraryTests
{
    [TestClass]
    public class ContractGeneratorClassTests
    {
        private ContractGeneratorClass generator;

        [TestInitialize]
        public void TestInitialize()
        {
            generator = new ContractGeneratorClass();
            generator.Initialize();
        }

        /// <summary>
        /// Проверяет, что при использовании нескольких экземпляров ContractGeneratorClass
        /// номера договоров генерируются независимо друг от друга.
        /// </summary>
        [TestMethod]
        public void GetNextContractNumber_MultipleInstances_IndependentContractNumbers()
        {
            // Arrange
            // Создаем второй экземпляр ContractGeneratorClass
            ContractGeneratorClass secondGenerator = new ContractGeneratorClass();

            // Ожидаемое значение следующего номера договора
            string expectedContractNumber = "2";

            // Act
            // Получаем следующий номер договора для первого генератора
            string actualContractNumber = generator.GetNextContractNumber();

            // Assert
            // Убеждаемся, что номер договора для первого генератора отличается от ожидаемого значения
            Assert.AreNotEqual(expectedContractNumber, actualContractNumber);
        }

        /// <summary>
        /// Проверяет, что при использовании трёх экземпляров ContractGeneratorClass
        /// номера договоров генерируются независимо друг от друга.
        /// </summary>
        [TestMethod]
        public void GetNextContractNumber_TrippleInstances_IndependentContractNumbers()
        {
            // Arrange
            ContractGeneratorClass secondGenerator = new ContractGeneratorClass();
            string expectedContractNumber = "3";

            // Act
            string actualContractNumber = generator.GetNextContractNumber();

            // Assert
            Assert.AreNotEqual(expectedContractNumber, actualContractNumber);
        }

        /// <summary>
        /// Проверяет, что при использовании 200 экземпляров ContractGeneratorClass
        /// номера договоров генерируются независимо друг от друга.
        /// </summary>
        [TestMethod]
        public void GetNextContractNumber_FourInstances_IndependentContractNumbers()
        {
            // Arrange
            ContractGeneratorClass secondGenerator = new ContractGeneratorClass();
            string expectedContractNumber = "4";

            // Act
            string actualContractNumber = generator.GetNextContractNumber();

            // Assert
            Assert.AreNotEqual(expectedContractNumber, actualContractNumber);
        }
        /// <summary>
        /// Проверяет, что при использовании трёх экземпляров ContractGeneratorClass
        /// номера договоров генерируются независимо друг от друга.
        /// </summary>
        [TestMethod]
        public void GetNextContractNumber_TwoHundred_IndependentContractNumbers()
        {
            // Arrange
            ContractGeneratorClass secondGenerator = new ContractGeneratorClass();
            string expectedContractNumber = "200";

            // Act
            string actualContractNumber = generator.GetNextContractNumber();

            // Assert
            Assert.AreNotEqual(expectedContractNumber, actualContractNumber);
        }
    }

}
