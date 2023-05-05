using DentistryClassLibrary;
using DentistryWpfApp.Model;
using DentistryWpfApp.View.Windows;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;
using System.Globalization;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateRegistratonPage.xaml
    /// </summary>
    public partial class CreateRegistratonPage : Page
    {
        int personalID;
        Core db = new Core();
        public CreateRegistratonPage(int personalId)
        {
            personalID = personalId;

           
            InitializeComponent();
           
           var clientsList=db.context.Clients.Where(x=>x.Personal_Id_FK==personalId).Select(p => p.Clients_Lastname ).ToList();
            for (int i = 0; i < clientsList.Count; i++) {
                ClientsComboBox.Items.Add(clientsList[i]);
            }
        }



        private void CreateRegButtonClick(object sender, RoutedEventArgs e)
        {
            if (!InputClass.HourChecking(HourTextBox.Text))
            {
                errorSnackbar.MessageQueue.Enqueue("Ошибка: Неверный формат времени", "OK", () => { });
            }
            else if(!RegistrationDatePicker.SelectedDate.HasValue)
            {
                errorSnackbar.MessageQueue.Enqueue("Ошибка: Неверный формат даты", "OK", () => { });
            }
            else 
            {
                // получаем выбранную дату из DatePicker
                DateTime date = (DateTime)RegistrationDatePicker.SelectedDate;

                // получаем значение времени из TextBox
                string timeString = HourTextBox.Text;

                // парсим время из строки в объект TimeSpan
                TimeSpan time = TimeSpan.ParseExact(timeString, "hh\\:mm", CultureInfo.InvariantCulture);

                // объединяем дату и время в объект DateTime
                DateTime result = date.Add(time);

                string LastName = ClientsComboBox.SelectionBoxItem.ToString();



                Registration registration = new Registration
                {
                    Registration_Date = result,
                    Clients_Id_FK = db.context.Clients.Where(x => x.Clients_Lastname == LastName).Where(x => x.Personal_Id_FK == personalID).Select(x => x.Clients_Id).First(),
                    Registration_Description=DescTextBox.Text,
                    
                
                
                };
                db.context.Registration.Add(registration);
                if(db.context.SaveChanges()>0) {
                    MessageBox.Show("Запись на приём успешно создана.");
                }
                else
                {
                    MessageBox.Show("Что-то не так.");
                }

            }
        }

       
    }
}
