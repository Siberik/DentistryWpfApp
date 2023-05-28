using DentistryWpfApp.Model;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private int idPersonal;
        Core db = new Core();
        public UserPage(int id,PhotoPersonal photo)
        {
            idPersonal = id;
            InitializeComponent();
            NameTextBox.Text=db.context.Personal.Where(x=>x.Personal_Id==id).Select(x=>x.Personal_Name).First();
            LastNameTextBox.Text=db.context.Personal.Where(x=>x.Personal_Id==id).Select(x=>x.Personal_LastName).First();
            SurnameTextBox.Text=db.context.Personal.Where(x=>x.Personal_Id==id).Select(x=>x.Personal_Surname).First();
            MailTextBox.Text = db.context.Personal.Where(x => x.Personal_Id == id).Select(x => x.Personal_Mail).First();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            Personal s = new Personal()
            {
                Personal_Id = idPersonal,
                Personal_LastName = LastNameTextBox.Text,
                Personal_Name = NameTextBox.Text,
                Personal_Surname = SurnameTextBox.Text,
                Personal_Login= db.context.Personal.Where(x => x.Personal_Id == idPersonal).Select(x => x.Personal_Login).First(),
                Personal_Mail= MailTextBox.Text,
                Personal_Password= db.context.Personal.Where(x => x.Personal_Id == idPersonal).Select(x => x.Personal_Password).First(),
                Role_Id_FK= db.context.Personal.Where(x => x.Personal_Id == idPersonal).Select(x => x.Role_Id_FK).First()


            };
            db.context.Personal.AddOrUpdate(s);
            if (db.context.SaveChanges() > 0)
            {
                MessageBox.Show("Сохранено.");
                
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }
        }
    }
}
