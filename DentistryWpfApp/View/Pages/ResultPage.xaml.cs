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

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        int idGet;
        Core db = new Core();
        public ResultPage(int clientsId)
        {
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

            // Открываем документ Word
            string fileName = "043у.docx";
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Assets\\Documents\\", fileName);

            // Создаем временную копию файла
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);
            System.IO.File.Copy(filePath, tempFilePath, true);

            // Создаем объект Word и открываем документ
            Microsoft.Office.Interop.Word.Application word = null;
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
                doc = word.Documents.Open(tempFilePath, ReadOnly: false, Visible: true);

                // Ваш остальной код
                // Получаем значения для вставки и задаем стиль "нижнее подчеркивание"
                string valueToInsert1 = "Место для рекламы";
                Microsoft.Office.Interop.Word.Range bookmark1 = doc.Bookmarks["ЛечащийВрач"].Range;
                bookmark1.Text = valueToInsert1;
                bookmark1.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

                string valueToInsert2 = "Лечащий драч";
                Microsoft.Office.Interop.Word.Range bookmark2 = doc.Bookmarks["ДанныеРентгеновскихИсследований"].Range;
                bookmark2.Text = valueToInsert2;
                bookmark2.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

                string name = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Name).FirstOrDefault();
                string surname = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Surname).FirstOrDefault();
                string lastname = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Lastname).FirstOrDefault();
                string valueToInsert3 = $"{lastname} {name} {surname}";
                Microsoft.Office.Interop.Word.Range bookmark3 = doc.Bookmarks["ФИО"].Range;
                bookmark3.Text = valueToInsert3;
                bookmark3.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

                string valueToInsert4 = $"{DateTime.Now:yy}";
                Microsoft.Office.Interop.Word.Range bookmark4 = doc.Bookmarks["ГодДвеПоследние"].Range;
                bookmark4.Text = valueToInsert4;
                bookmark4.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

                string valueToInsert5 = $"{DateTime.Now.Day}";
                Microsoft.Office.Interop.Word.Range bookmark5 = doc.Bookmarks["Число"].Range;
                bookmark5.Text = valueToInsert5;
                bookmark5.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;




                DateTime now = DateTime.Now;
                string monthName = now.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru-RU"));

                string[] monthCases = new string[] { "января", "февраля", "марта", "апреля", "мая", "июня",
                                     "июля", "августа", "сентября", "октября", "ноября", "декабря" };

                int monthNumber = now.Month;
                string inflectedMonthName = monthCases[monthNumber - 1];

                string result = inflectedMonthName;
                Console.WriteLine(result);

                string valueToInsert6 = result;

                string valueToInsert7 = contractGenerator.GetNextContractNumber();
                Microsoft.Office.Interop.Word.Range bookmark7 = doc.Bookmarks["Номер"].Range;
                bookmark7.Text = valueToInsert7;
                bookmark7.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;


                Microsoft.Office.Interop.Word.Range bookmark6 = doc.Bookmarks["Месяц"].Range;
                bookmark6.Text = valueToInsert6;
                bookmark6.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;



                var gender = db.context.Clients.Where(x=>x.Clients_Id==idGet).Select(x=>x.Clients_Gender).FirstOrDefault();
                string valueToInsert8 = gender;
                Microsoft.Office.Interop.Word.Range bookmark8 = doc.Bookmarks["Пол"].Range;
                
                bookmark8.Text = valueToInsert8;
                bookmark8.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

                var adress = db.context.Clients.Where(x => x.Clients_Id == idGet).Select(x => x.Clients_Adress).FirstOrDefault();
                string valueToInsert9 = gender;
                Microsoft.Office.Interop.Word.Range bookmark9 = doc.Bookmarks["Адрес"].Range;

                bookmark8.Text = valueToInsert9;
                bookmark8.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;


                // Показываем документ Word пользователю
                word.Visible = true;
                // Закрываем документ и освобождаем ресурсы
                doc.Close();
                word.Quit();
            }
            finally
            {
                if (doc != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                if (word != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(word);

                doc = null;
                word = null;
                GC.Collect();
            }

            // Открываем временный файл в программе по умолчанию
            System.Diagnostics.Process.Start(tempFilePath);

            MessageBox.Show("Значения успешно добавлены в Word!");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Переключаем видимость разделов

            if (Section1.Visibility == Visibility.Visible)
            {
                // Если отображается раздел 1, переключаем на раздел 2
                Section1.Visibility = Visibility.Collapsed;
                Section2.Visibility = Visibility.Visible;
                NextButton.Content = "Сохранить";
                NextButton.Click -= NextButton_Click;
                NextButton.Click += AddToWordButton_Click;

            }
            else if (Section2.Visibility == Visibility.Visible)
            {
                // Если отображается раздел 2, выполните необходимые действия
                // и переключите обратно на раздел 1 или скройте кнопку "Далее"
                // в зависимости от ваших требований
                
                NextButton.Content = "Сохранить";
                
            }
        }

        private void SaveData()
        {
            // Здесь можно выполнить необходимые действия для сохранения данных
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик событий для кнопки "Сохранить"
            SaveData();

            // Скрываем кнопку "Далее"
            NextButton.Visibility = Visibility.Collapsed;
        }
    }
}


