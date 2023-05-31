using DentistryWpfApp.Model;
using DentistryWpfApp.View.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RedactingPatientPage.xaml
    /// </summary>
    public partial class RedactingPatientPage : Page
    {
        string gender;
        private int idget = 0;
        Core db = new Core();
        public RedactingPatientPage(int id)
        {
            idget = id;
            InitializeComponent();
            NameTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Name).FirstOrDefault();
            LastNameTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Lastname).FirstOrDefault();
            SurnameTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Surname).FirstOrDefault();
            PhoneTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Phone).FirstOrDefault();
            ClientDateTextBox.SelectedDate = (DateTime)db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Date).FirstOrDefault();
            AdressTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Adress).FirstOrDefault();
            ProfTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Prof).FirstOrDefault();



           
            EditTableDent.CellTextChanged += EditableTable_CellTextChanged;
            string phone = PhoneTextBox.Text;
            PhoneTextBox.Text = phone;
            // Получение зубной формулы пациента из базы данных
            DentalFormula dentalFormula = db.context.DentalFormula.FirstOrDefault(f => f.Client_Id_FK == idget);

            // Проверка наличия зубной формулы
            if (dentalFormula != null)
            {
                // Получение строки с зубной формулой
                string formulaString = dentalFormula.DentalFormula_Formula;

                // Разделение строки на отдельные числа
                string[] formulaValues = formulaString.Split(',');

                // Получение всех текстовых полей в EditTableDent
                List<List<TextBox>> textBoxes = EditTableDent.GetTextBoxes();

                // Заполнение текстовых полей значениями из разделенной строки
                int valueIndex = 0;
                foreach (var rowTextBoxes in textBoxes)
                {
                    foreach (var textBox in rowTextBoxes)
                    {
                        // Проверка на выход за пределы массива formulaValues
                        if (valueIndex < formulaValues.Length)
                        {
                            string value = formulaValues[valueIndex];
                            textBox.Text = value;
                            valueIndex++;
                        }
                    }
                }
            }
        }
        private void EditableTable_Initialized(object sender, EventArgs e)
        {
            // Получение ссылки на объект EditableTable, который вызвал событие
            EditableTable editableTable = (EditableTable)sender;

            // Пример кода обработки события Initialized для EditableTable
            // ...

            // Например, установка начальных значений или настройка параметров EditableTable

            // Инициализация таблицы
            editableTable.Initialize();

            // ...
        }

        private void EditableTable_CellTextChanged(object sender, CellTextChangedEventArgs e)
        {

        }




        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            Clients s = new Clients()
            {
                Clients_Id = idget,
                Clients_Name = NameTextBox.Text,
                Clients_Surname = SurnameTextBox.Text,
                Clients_Lastname = LastNameTextBox.Text,
                Clients_Phone = PhoneTextBox.Text,
                Personal_Id_FK = db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Personal_Id_FK).FirstOrDefault(),
                Clients_Date = ClientDateTextBox.SelectedDate,
                Clients_Adress = AdressTextBox.Text,
                Clients_Prof = ProfTextBox.Text,
                Clients_Gender = gender,

            };

            // Получение значений из EditableTable и создание строки с разделителями ","
            StringBuilder editableTableValues = new StringBuilder();
            List<List<TextBox>> textBoxes = EditTableDent.GetTextBoxes();
            foreach (var rowTextBoxes in textBoxes)
            {
                foreach (var textBox in rowTextBoxes)
                {
                    string value = textBox.Text;
                    if (string.IsNullOrEmpty(value))
                    {
                        value = "0";
                    }
                    editableTableValues.Append(value);
                    editableTableValues.Append(",");
                }
            }
            string tableValuesString = editableTableValues.ToString().TrimEnd(',');
            // Используйте полученную строку со значениями в EditableTable
            Console.WriteLine(tableValuesString);
            DentalFormula formula = new DentalFormula()
            {
                DentalFormula_Formula = tableValuesString,
                Client_Id_FK = s.Clients_Id,
                DentalFormula_Id = db.context.DentalFormula.Where(x=>x.Client_Id_FK==s.Clients_Id).Select(x=>x.DentalFormula_Id).FirstOrDefault(),


            };
            db.context.DentalFormula.AddOrUpdate(formula);

            db.context.Clients.AddOrUpdate(s);
            if (db.context.SaveChanges() > 0)
            {
                MessageBox.Show("Сохранено.");
                this.NavigationService.Navigate(new ViewingPatientPage(idget));
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string selectedGender = radioButton.Content.ToString();
            gender = selectedGender;

        }
    }
}
