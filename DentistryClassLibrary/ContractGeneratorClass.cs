using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistryClassLibrary
{
    public class ContractGeneratorClass
    {
        private int contractNumber;

        public ContractGeneratorClass()
        {
            // Загружаем значение договора из сохраненного источника данных (например, базы данных)
            // В данном примере используется просто начальное значение 1
            contractNumber = 1;
        }

        public string GetNextContractNumber()
        {
            // Генерируем номер текущего договора на основе текущего значения
            string currentContractNumber = contractNumber.ToString();

            // Увеличиваем значение договора для следующего договора
            contractNumber++;

            // Сохраняем значение договора в источнике данных (например, базе данных)

            return currentContractNumber;
        }
    }
}
