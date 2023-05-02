using DentistryWpfApp.Model;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ViewingPatientPage.xaml
    /// </summary>
    public partial class ViewingPatientPage : Page
    {
        private int idget = 0;
        Core db= new Core();
        public ViewingPatientPage(int id)
        {
            idget = id;
            string name= db.context.Clients.Where(x=>x.Clients_Id==id).Select(x=>x.Clients_Name).FirstOrDefault();
            string surname= db.context.Clients.Where(x=>x.Clients_Id==id).Select(x=>x.Clients_Surname).FirstOrDefault();
            string lastname= db.context.Clients.Where(x=>x.Clients_Id==id).Select(x=>x.Clients_Lastname).FirstOrDefault();
            string phone = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Phone).FirstOrDefault(); ;
            InitializeComponent();
            IdTextBlock.Text = $"Id клиента: {id}";
            LastNameTextBlock.Text =$"Фамилия: {lastname}";
            NameTextBlock.Text =$"Имя : {name}";
            SurnameTextBlock.Text = $"Отчество: {surname}";
            PhoneTextBlock.Text = $"Телефон: {phone}";
            
        }

       

        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RedactingPatientPage(idget));
        }

     

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            
            Clients clientsDelete = new Clients()
            {
                Clients_Name= db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Clients_Name).FirstOrDefault(),
                Clients_Lastname= db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Clients_Lastname).FirstOrDefault(),
                Clients_Phone= db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Clients_Phone).FirstOrDefault(),
                Clients_Surname= db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Clients_Surname).FirstOrDefault(),
                Personal_Id_FK= db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Personal_Id_FK).FirstOrDefault(),
                Clients_Id= db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Clients_Id).FirstOrDefault(),
                
               
            };
          
        
          
            if (!db.context.Clients.Local.Contains(clientsDelete))
            {
                db.context.Clients.Attach(clientsDelete);
            }
            EntityState state = db.context.Entry(clientsDelete).State;
            if (state != EntityState.Deleted)
            {
                db.context.Entry(clientsDelete).State = EntityState.Deleted;
                int clientId = clientsDelete.Clients_Id; // id клиента
                var registrations = db.context.Registration.Where(r => r.Clients_Id_FK == clientId).ToList();

                foreach (var registration in registrations)
                {
                    db.context.Registration.Remove(registration);
                }

                db.context.SaveChanges();
            }
            
            if (db.context.SaveChanges() > 0)
            {
                MessageBox.Show("Удаление сделано.");
            }
            else
            {
                MessageBox.Show("Удаление сделано. Привязанных к клиенту приёмов не обнаружено.");
            }

        }
    }
}
