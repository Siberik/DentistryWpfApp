using DentistryWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Удаляем кнопку из контейнера при нажатии на нее
            var serviceButton = sender as Button;
            if (serviceButton != null)
            {
                servicesContainer.Children.Remove(serviceButton);
            }
        }
    }
}
