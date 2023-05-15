using DentistryWpfApp.Model;
using Humanizer;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Humanizer;


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
        string GetMonthName(int month, InflectionCase inflectionCase)
        {
            var culture = new CultureInfo("ru-RU");
            var dateTimeFormatInfo = culture.DateTimeFormat;

            var monthName = dateTimeFormatInfo.GetMonthName(month);

            switch (inflectionCase)
            {
                case InflectionCase.Genitive:
                    if (month == 3 || month == 8)
                    {
                        monthName += "а";
                    }
                    else if (month == 1 || month == 2 || month == 4 || month == 5 || month == 7 || month == 10 || month == 11)
                    {
                        monthName += "я";
                    }
                    else
                    {
                        monthName += "ь";
                    }
                    break;
                default:
                    break;
            }

            return monthName;
        }
        private void AddToWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр приложения Word
          

            // Устанавливаем параметры приложения
            

            // Открываем документ Word
            string fileName = "043у.docx";
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Assets\\Documents\\", fileName);
           

            // Создаем временную копию файла
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);
            System.IO.File.Copy(filePath, tempFilePath, true);

            // Создаем объект Word и открываем документ
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(tempFilePath, ReadOnly: false, Visible: true);

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
            



            Microsoft.Office.Interop.Word.Range bookmark6 = doc.Bookmarks["Месяц"].Range;
            bookmark6.Text = valueToInsert6;
            bookmark6.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            // Показываем документ Word пользователю
            word.Visible = true;

            // Закрываем документ и освобождаем ресурсы
            doc.Close();
            word.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(word);
            GC.Collect();

            // Открываем временный файл в программе по умолчанию
            System.Diagnostics.Process.Start(tempFilePath);

            MessageBox.Show("Значения успешно добавлены в Word!");

        }
       

    }
}
