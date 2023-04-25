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
    /// Логика взаимодействия для NotesDentistPAge.xaml
    /// </summary>
    public partial class NotesDentistPage : Page
    {
        Core db = new Core();
        public NotesDentistPage(int personalId)
        {
            InitializeComponent();

           
            for (int i = 0; i < 0; i++)
            {

            }
        }
    }
}
