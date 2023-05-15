using DentistryWpfApp.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        Core db = new Core();
        public ResultPage(int clientsId)
        {
            InitializeComponent();

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

        private void AddToWordButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            object missing = System.Reflection.Missing.Value;
            string fileName = "043у.docx";
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Assets\\Documents\\", fileName);

            // Открываем документ Word
            object file = filePath;
            doc = word.Documents.Open(ref file, ReadOnly: false, Visible: true);

            // Получаем значения для вставки и задаем стиль "нижнее подчеркивание"
            string valueToInsert1 = "Место для рекламы";
            Microsoft.Office.Interop.Word.Range bookmark1 = doc.Bookmarks["ЛечащийВрач"].Range;
            bookmark1.Text = valueToInsert1;
            bookmark1.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

            string valueToInsert2 = "Лечащий драч";
            Microsoft.Office.Interop.Word.Range bookmark2 = doc.Bookmarks["ДанныеРентгеновскихИсследований"].Range;
            bookmark2.Text = valueToInsert2;
            bookmark2.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

            // Показываем документ Word пользователю
            word.Visible = true;

            // Освобождаем ресурсы
            doc = null;
            word = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            MessageBox.Show("Значения успешно добавлены в Word!");
        }

    }
}
