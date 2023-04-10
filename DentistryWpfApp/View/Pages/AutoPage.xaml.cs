﻿using DentistryWpfApp.Model;
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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        readonly Core db = new Core();
        private void AuthorizeButtonClick(object sender, RoutedEventArgs e)
        {
            string role = "";
            string name = "";
            string lastname = "";
            string surname = "";
            int roleId = 0;
            if (db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password).FirstOrDefault() != null)
            {
                roleId = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password).Select(x => x.Role_Id_FK).FirstOrDefault();
                role = db.context.Role.Where(x => x.Role_Id == roleId).Select(x => x.Role_Name).FirstOrDefault();

                name = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_Name).FirstOrDefault();
                lastname = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_LastName).FirstOrDefault();
                surname = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_Surname).FirstOrDefault();

                var newForm = new MainWindow(roleId, role, name, lastname, surname); //create your new form.
                newForm.Show();

                Application.Current.MainWindow.Close();




            }
            else
            {
                MessageBox.Show("Введены неверные данные!");
            }



        }

       

        private void ResetTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ResetPasswordPage());
        }
    }
}