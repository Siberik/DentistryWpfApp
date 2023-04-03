﻿using System;
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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(string name,string lastname,string role,string surname=null)
        {
            string timeNow;
            if(DateTime.Now.Hour>=0&& DateTime.Now.Hour<4)
            {
                timeNow = "Доброй ночи";
            }
            else if(DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 12)
            {
                timeNow = "Доброе утро";
            }
            else if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                timeNow = "Доброго дня";
            }
            else
            {
                timeNow = "Доброго вечера";
            }
            InitializeComponent();
            NameTextBlock.Text = $"{timeNow}, {lastname} {name} {surname}!";
            RoleTextBlock.Text = $"Ваша роль: {role}";
        }
    }
}