using DentistryWpfApp.Model;
using Humanizer;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DentistryClassLibrary;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Data.Entity.Migrations;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : System.Windows.Controls.Page
    {
        Registration reg;
        int idGet;
        Core db = new Core();
        public ResultPage(int clientsId, Registration registration)
        {
            reg= registration;
            contractGenerator = new ContractGeneratorClass();
            InitializeComponent();
            idGet = clientsId;
            // Получаем список всех услуг
            var servicesList = db.context.Services.ToList();
            // Заполняем ComboBox объектами типа Services
            servicesComboBox.ItemsSource = servicesList;
            // Устанавливаем отображаемое значение в ComboBox
            servicesComboBox.DisplayMemberPath = "Services_Code";
            // Устанавливаем значение, которое будет использоваться в качестве SelectedValue
            servicesComboBox.SelectedValuePath = "Services_Id";
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную услугу
            var selectedService = servicesComboBox.SelectedItem as Services;

            if (selectedService != null)
            {
                // Создаем кнопку с кодом услуги и добавляем ее в контейнер
                var serviceButton = new Button();
                serviceButton.Content = selectedService.Services_Code;
                serviceButton.Tag = selectedService.Services_Id;
                serviceButton.Margin = new Thickness(10, 0, 0, 0);
                // Добавляем обработчики событий для кнопки
                serviceButton.MouseEnter += ServiceButton_MouseEnter;
                serviceButton.MouseLeave += ServiceButton_MouseLeave;
                serviceButton.Click += ServiceButton_Click;

                servicesContainer.Children.Add(serviceButton);
            }
        }

        private void ServiceButton_MouseEnter(object sender, MouseEventArgs e)
        {
            // Изменяем цвет кнопки при наведении мыши
            var serviceButton = sender as Button;

            if (serviceButton != null)
            {
                serviceButton.Background = Brushes.Red;
            }
        }
        private void ServiceButton_MouseLeave(object sender, MouseEventArgs e)
        {
            // Изменяем цвет кнопки при наведении мыши
            var serviceButton = sender as Button;

            if (serviceButton != null)
            {
                serviceButton.Background = Brushes.Gray;
            }
        }

        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Удаляем кнопку из контейнера при нажатии на нее
            var serviceButton = sender as Button;
            if (serviceButton != null)
            {
                servicesContainer.Children.Remove(serviceButton);
            }
        }
        enum InflectionCase
        {
            Nominative,
            Genitive,
            Dative,
            Accusative,
            Instrumental,
            Prepositional
        }
        private ContractGeneratorClass contractGenerator;




       

private void AddToWordButton_Click(object sender, RoutedEventArgs e)
        {
            ContractGeneratorClass contractGeneratorClass = new ContractGeneratorClass();

            // Открываем исходный документ Word
            string fileName = "043у.docx";
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Assets\\Documents\\", fileName);

            // Создаем временную копию файла
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);
            System.IO.File.Copy(filePath, tempFilePath, true);

            // Создаем объект Word и открываем временную копию документа
            Microsoft.Office.Interop.Word.Application word = null;
            Microsoft.Office.Interop.Word.Document tempDoc = null;
            var client = db.context.Clients.FirstOrDefault(x => x.Clients_Id == idGet);
            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
                tempDoc = word.Documents.Open(tempFilePath, ReadOnly: false, Visible: true);

                // Задаем стиль "Times New Roman, 14 кеглей" для текстовых элементов
                Font font = tempDoc.Content.Font;
                font.Name = "Times New Roman";
              

                ParagraphFormat paragraphFormat = tempDoc.Content.ParagraphFormat;
                paragraphFormat.SpaceAfter = 0;
                paragraphFormat.SpaceBefore = 0;

                // Вставляем значения в соответствующие закладки
                Personal personal = db.context.Personal.FirstOrDefault(x => x.Personal_Id == client.Personal_Id_FK);
                // Закладка "ЛечащийВрач"
                string valueToInsert1 = $"{personal.Personal_LastName} {personal.Personal_Name} {personal.Personal_Surname}";
                Range bookmark1 = tempDoc.Bookmarks["ЛечащийВрач"].Range;
                bookmark1.Text = valueToInsert1;
                bookmark1.Underline = WdUnderline.wdUnderlineSingle;

                string name = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Name).FirstOrDefault();
                string surname = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Surname).FirstOrDefault();
                string lastname = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Lastname).FirstOrDefault();
                string valueToInsert3 = $"{lastname} {name} {surname}";
                Range bookmark3 = tempDoc.Bookmarks["ФИО"].Range;
                bookmark3.Text = valueToInsert3;
                bookmark3.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert4 = $"{DateTime.Now:yy}";
                Range bookmark4 = tempDoc.Bookmarks["ГодДвеПоследние"].Range;
                bookmark4.Text = valueToInsert4;
                bookmark4.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert5 = $"{DateTime.Now.Day}";
                Range bookmark5 = tempDoc.Bookmarks["Число"].Range;
                bookmark5.Text = valueToInsert5;
                bookmark5.Underline = WdUnderline.wdUnderlineSingle;

                DateTime now = DateTime.Now;
                string monthName = now.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru-RU"));

                string[] monthCases = new string[] { "января", "февраля", "марта", "апреля", "мая", "июня",
                                             "июля", "августа", "сентября", "октября", "ноября", "декабря" };

                int monthNumber = now.Month;
                string inflectedMonthName = monthCases[monthNumber - 1];

                string valueToInsert6 = inflectedMonthName;
                Range bookmark6 = tempDoc.Bookmarks["Месяц"].Range;
                bookmark6.Text = valueToInsert6;
                bookmark6.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert7 = contractGenerator.GetNextContractNumber();
                Range bookmark7 = tempDoc.Bookmarks["Номер"].Range;
                bookmark7.Text = valueToInsert7;
                bookmark7.Underline = WdUnderline.wdUnderlineSingle;

                var gender = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Gender).FirstOrDefault();
                string valueToInsert8 = gender;
                Range bookmark8 = tempDoc.Bookmarks["Пол"].Range;
                bookmark8.Text = valueToInsert8;
                bookmark8.Underline = WdUnderline.wdUnderlineSingle;

                var adress = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Adress).FirstOrDefault();
                string valueToInsert9 = adress;
                Range bookmark9 = tempDoc.Bookmarks["Адрес"].Range;
                bookmark9.Text = valueToInsert9;
                bookmark9.Underline = WdUnderline.wdUnderlineSingle;

                int age = 0;
                if (client != null)
                {
                    DateTime birthDate = (DateTime)client.Clients_Date;
                    DateTime currentDate = DateTime.Now;
                    age = currentDate.Year - birthDate.Year;

                    if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
                    {
                        age--;
                    }
                }

                string valueToInsert10 = age.ToString();
                Range bookmark10 = tempDoc.Bookmarks["Возраст"].Range;
                bookmark10.Text = valueToInsert10;
                bookmark10.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert11 = client.Clients_Prof;
                Range bookmark11 = tempDoc.Bookmarks["Профессия"].Range;
                bookmark11.Text = valueToInsert11;
                bookmark11.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert12 = TransferredDiseasesTextBox.Text;
                Range bookmark12 = tempDoc.Bookmarks["СопутствующиеЗаблоевания"].Range;
                bookmark12.Text = valueToInsert12;
                bookmark12.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert13 = СomplaintsTextBox.Text;
                Range bookmark13 = tempDoc.Bookmarks["Жалобы"].Range;
                bookmark13.Text = valueToInsert13;
                bookmark13.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert14 = RealDiseaseTextBox.Text;
                Range bookmark14 = tempDoc.Bookmarks["РазвитиеНастоящегоЗаболевания"].Range;
                bookmark14.Text = valueToInsert14;
                bookmark14.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert15 = MucousMembraneTextBox.Text;
                Range bookmark15 = tempDoc.Bookmarks["СостояниеСлизистой"].Range;
                bookmark15.Text = valueToInsert15;
                bookmark15.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert16 = RentgenTextBox.Text;
                Range bookmark16 = tempDoc.Bookmarks["ДанныеРентгеновскихИсследований"].Range;
                bookmark16.Text = valueToInsert16;
                bookmark16.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert17 = ResultTextBox.Text;
                Range bookmark17 = tempDoc.Bookmarks["Эпикриз"].Range;
                bookmark17.Text = valueToInsert17;
                bookmark17.Underline = WdUnderline.wdUnderlineSingle;

                string valueToInsert18 = SovetTextBox.Text;
                Range bookmark18 = tempDoc.Bookmarks["Наставления"].Range;
                bookmark18.Text = valueToInsert18;
                bookmark18.Underline = WdUnderline.wdUnderlineSingle;

                // Сохраняем временную копию файла с данными
                tempDoc.Save();

                // Открываем временный файл в программе по умолчанию
                System.Diagnostics.Process.Start(tempFilePath);

                MessageBox.Show("Значения успешно добавлены в Word!");
            }
            finally
            {
                if (tempDoc != null)
                    Marshal.ReleaseComObject(tempDoc);
                if (word != null)
                    Marshal.ReleaseComObject(word);

                tempDoc = null;
                word = null;
                GC.Collect();
            }

            Visits visits = new Visits()
            {
                Visits_Date = reg.Registration_Date,
                Visits_Diagnosis=DiagnosisTextBox.Text,
                Visits_RealDisease=RealDiseaseTextBox.Text,
                Visits_Rentgen=RentgenTextBox.Text,
                Visits_Sovet=SovetTextBox.Text,
                Visits_MucousMembrane=MucousMembraneTextBox.Text,
                Visits_Result=ResultTextBox.Text,
                Visits_TransferredDiseases=TransferredDiseasesTextBox.Text,
                Visits_Complaints = СomplaintsTextBox.Text,
                Clients_Id_FK=(int)reg.Clients_Id_FK,
            };
            reg.Visits_Id_FK = visits.Visits_Id;
            db.context.Visits.Add(visits);
            db.context.Registration.AddOrUpdate(reg);
            
           if(db.context.SaveChanges() == 0)
            {
                MessageBox.Show("Ты лоханулся, дружок");
            }
        }




        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Переходите на предыдущую страницу
            Section1.Visibility = Visibility.Visible;
            Section2.Visibility = Visibility.Collapsed ;
        }

        private void SaveData()
        {
            // Здесь можно выполнить необходимые действия для сохранения данных
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь можно выполнить необходимые действия для сохранения данных

            // Проверяем, находимся ли мы на последней странице (разделе)
            if (Section2.Visibility == Visibility.Visible)
            {
                // Если да, то сохраняем данные и скрываем кнопку "Далее"
                SaveData();
                NextButton.Visibility = Visibility.Collapsed;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (Section1.Visibility == Visibility.Visible)
            {
                // Если отображается раздел 1, переключаем на раздел 2
                Section1.Visibility = Visibility.Collapsed;
                Section2.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Visible;
                NextButton.Content = "Сохранить";
                NextButton.Click -= NextButton_Click;
                NextButton.Click += AddToWordButton_Click;

                // Скрываем кнопку "Сохранить" на первом разделе
              
            }
            else if (Section2.Visibility == Visibility.Visible)
            {
                // Если отображается раздел 2, выполните необходимые действия
                // и переключите обратно на раздел 1 или скройте кнопку "Далее"
                // в зависимости от ваших требований

                NextButton.Content = "Сохранить";
            }
        }

    }
}


 