using DentistryWpfApp.Model;
using DentistryWpfApp.View.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DentistryWpfApp.View.Windows
{
    public partial class AddPatientWindow : Window
    {
        string gender;
        private bool isDragging = false;
        private double x = 0;
        private double y = 0;

        Core db = new Core();
        public AddPatientWindow()
        {
            InitializeComponent();

            // Загрузка таблицы Excel

            DentistComboBox.ItemsSource = db.context.Personal.ToList();
            DentistComboBox.DisplayMemberPath = "Personal_LastName";
            
            EditableTable editableTable = new EditableTable();
            editableTable.CellTextChanged += EditableTable_CellTextChanged;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            x = e.GetPosition(this).X;
            y = e.GetPosition(this).Y;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string selectedGender = radioButton.Content.ToString();
            gender = selectedGender;
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                double newX = this.Left + (e.GetPosition(this).X - x);
                double newY = this.Top + (e.GetPosition(this).Y - y);

                this.Left = newX;
                this.Top = newY;
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                int textComboBox = DentistComboBox.SelectedIndex + 1;
                Console.WriteLine(textComboBox);
                var dentistId = db.context.Personal.Where(x => x.Personal_Id == textComboBox).Select(x => x.Personal_Id).FirstOrDefault();
                Clients newClient = new Clients()
                {
                    Clients_Name = NameTextBox.Text,
                    Clients_Lastname = LastNameTextBox.Text,
                    Clients_Phone = PhoneTextBox.Text,
                    Clients_Surname = SurnameTextBox.Text,
                    Personal_Id_FK = dentistId,
                    Clients_Date = ClientsDatePicker.SelectedDate,
                    Clients_Prof = ProfTextBox.Text,
                    Clients_Adress = AdressTextBox.Text,
                    Clients_Gender = gender,
                };
                db.context.Clients.Add(newClient);

                if (db.context.SaveChanges() > 0)
                {
                    MessageBox.Show("Новый клиент создан.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Не удалось создать клиента.");
                }
            }
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            List<TextBox> requiredTextBoxes = new List<TextBox>
            {
                NameTextBox,
                LastNameTextBox,
                PhoneTextBox,
                SurnameTextBox,
                ProfTextBox,
                AdressTextBox
            };

            foreach (TextBox textBox in requiredTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.BorderBrush = Brushes.Red;
                    isValid = false;
                }
                else
                {
                    textBox.ClearValue(Border.BorderBrushProperty);
                }
            }

            if (ClientsDatePicker.SelectedDate == null)
            {
                ClientsDatePicker.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                ClientsDatePicker.ClearValue(Border.BorderBrushProperty);
            }

            return isValid;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Переключение видимости разделов
            Section1.Visibility = Visibility.Collapsed;
            Section2.Visibility = Visibility.Visible;

            // Скрытие кнопки "NextButton"
            NextButton.Visibility = Visibility.Collapsed;
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
    }
}
