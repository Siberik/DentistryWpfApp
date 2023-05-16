using System.IO;

namespace DentistryClassLibrary
{
    public class ContractGeneratorClass
    {
        private int contractNumber;
        private string fileName = "contract_number.txt";

        public ContractGeneratorClass()
        {
            // Загружаем значение договора из файла, если он существует
            if (File.Exists(fileName))
            {
                string savedContractNumber = File.ReadAllText(fileName);
                if (int.TryParse(savedContractNumber, out int parsedContractNumber))
                {
                    contractNumber = parsedContractNumber;
                }
                else
                {
                    // В случае ошибки при парсинге значения, устанавливаем начальное значение 1
                    contractNumber = 1;
                }
            }
            else
            {
                // В случае отсутствия файла, устанавливаем начальное значение 1
                contractNumber = 1;
            }
        }

        public string GetNextContractNumber()
        {
            // Генерируем номер текущего договора на основе текущего значения
            string currentContractNumber = contractNumber.ToString();

            // Увеличиваем значение договора для следующего договора
            contractNumber++;

            // Сохраняем значение договора в файл
            File.WriteAllText(fileName, contractNumber.ToString());

            return currentContractNumber;
        }
    }
}
