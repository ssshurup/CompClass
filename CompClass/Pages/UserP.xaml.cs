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

namespace CompClass.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserP.xaml
    /// </summary>
    public partial class UserP : Page
    {
        public UserP()
        {
            InitializeComponent();
            CompListDG.ItemsSource = App.DB.computers.ToList();
            ChoiseCB.ItemsSource = App.DB.classes.ToList();
        }
        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddP());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void ClassAddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClassP());

        }

        private void ShowBT_Click(object sender, object e)
        {
            classes cl = new classes();
            var Cl = App.DB.classes.Where(a => a.number == ChoiseCB.Text);
            if (Cl.Any() == true)
            {
                foreach (classes c in Cl)
                {
                    cl.id = c.id;
                }
            }
            else
            {
                MessageBox.Show("Enter Class");
                return;
            }
            computers comp = new computers();
            comp.idClass = cl.id;
            CompListDG.ItemsSource = App.DB.computers.ToList().Where(a => a.idClass == comp.idClass);
        }

        private void ShowAllBT_Click(object sender, RoutedEventArgs e)
        {
            CompListDG.ItemsSource = App.DB.computers.ToList();
        }
    }
}
