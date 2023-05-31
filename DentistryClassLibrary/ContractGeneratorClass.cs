using System.IO;

namespace DentistryClassLibrary
{
    public class ContractGeneratorClass
    {
        private int contractNumber;
        private readonly string fileName = "contract_number.txt";
        public string FileName => fileName;

        public ContractGeneratorClass()
        {
            LoadContractNumber();
        }

        public void Initialize()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private void LoadContractNumber()
        {
            if (File.Exists(fileName))
            {
                string savedContractNumber = File.ReadAllText(fileName);
                if (int.TryParse(savedContractNumber, out int parsedContractNumber))
                {
                    contractNumber = parsedContractNumber;
                }
                else
                {
                    contractNumber = 1;
                    SaveContractNumber();
                }
            }
            else
            {
                contractNumber = 1;
                SaveContractNumber();
            }
        }

        private void SaveContractNumber()
        {
            File.WriteAllText(fileName, contractNumber.ToString());
        }

        public string GetNextContractNumber()
        {
            contractNumber++;
            SaveContractNumber();
            return contractNumber.ToString();
        }
    }
}
