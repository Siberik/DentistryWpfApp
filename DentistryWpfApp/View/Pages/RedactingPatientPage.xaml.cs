using DentistryWpfApp.Model;
using DentistryWpfApp.View.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace DentistryWpfApp.View.Pages
{
    public partial class RedactingPatientPage : Page
    {
        private string gender;
        private int idget = 0;
        private Core db = new Core();
        private StackPanel EditableTableContainer;

        public RedactingPatientPage(int id)
        {
            idget = id;
            InitializeComponent();

            // Заполнение полей данными из базы данных
            Clients client = db.context.Clients.FirstOrDefault(x => x.Clients_Id == id);
            if (client != null)
            {
                NameTextBox.Text = client.Clients_Name;
                LastNameTextBox.Text = client.Clients_Lastname;
                SurnameTextBox.Text = client.Clients_Surname;
                PhoneTextBox.Text = client.Clients_Phone;
                ClientDateTextBox.SelectedDate = client.Clients_Date;
                AdressTextBox.Text = client.Clients_Adress;
                ProfTextBox.Text = client.Clients_Prof;
                gender = client.Clients_Gender;
            }

            EditableTableContainer = new StackPanel();
            // Добавьте его на страницу
            ContentPanel.Children.Add(EditableTableContainer);


            EditTableDent.CellTextChanged += (sender, e) => EditableTable_CellTextChanged(sender, e);
            string phone = PhoneTextBox.Text;
            PhoneTextBox.Text = phone;

            // Получение значения DentalFormula_Formula из базы данных по id
            DentalFormula dentalFormula = db.context.DentalFormula.FirstOrDefault(x => x.Client_Id_FK == id);
            if (dentalFormula != null)
            {
                string formula = dentalFormula.DentalFormula_Formula;

                // Заполнение edittable значениями из DentalFormula_Formula
                for (int i = 0; i < formula.Length; i++)
                {
                    TextBox cell = EditTableDent.GetTextBoxAtPosition(i % EditTableDent.Columns, i / EditTableDent.Columns);
                    if (cell != null)
                    {
                        cell.Text = formula[i].ToString();
                    }
                }
            }

            // Добавление EditableTable на страницу
            EditableTableContainer.Children.Add(EditTableDent);
        }

        private void EditableTable_CellTextChanged(object sender, CellTextChangedEventArgs e)
        {
            // Обработка изменения значения в ячейке EditableTable
            // Можно добавить соответствующую логику здесь
        }


        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            // Сохранение изменений в базу данных

            Clients client = db.context.Clients.FirstOrDefault(x => x.Clients_Id == idget);
            if (client != null)
            {
                client.Clients_Name = NameTextBox.Text;
                client.Clients_Lastname = LastNameTextBox.Text;
                client.Clients_Surname = SurnameTextBox.Text;
                client.Clients_Phone = PhoneTextBox.Text;
                client.Clients_Date = ClientDateTextBox.SelectedDate;
                client.Clients_Adress = AdressTextBox.Text;
                client.Clients_Prof = ProfTextBox.Text;
                client.Clients_Gender = gender;
            }

            DentalFormula dentalFormula = db.context.DentalFormula.FirstOrDefault(x => x.Client_Id_FK == idget);
            if (dentalFormula != null)
            {
                StringBuilder editableTableValues = new StringBuilder();
                EditableTable editableTable = EditableTableContainer.Children.OfType<EditableTable>().FirstOrDefault();
                if (editableTable != null)
                {
                    List<List<TextBox>> textBoxes = editableTable.GetTextBoxes();
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
                }

                dentalFormula.DentalFormula_Formula = editableTableValues.ToString().TrimEnd(',');
                dentalFormula.Client_Id_FK = client.Clients_Id;
            }

            db.context.SaveChanges();

            MessageBox.Show("Сохранено.");
            this.NavigationService.Navigate(new ViewingPatientPage(idget));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string selectedGender = radioButton.Content.ToString();
            gender = selectedGender;
        }
    }
}
