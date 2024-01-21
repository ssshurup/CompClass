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
    /// Логика взаимодействия для AddP.xaml
    /// </summary>
    public partial class AddP : Page
    {
        public AddP()
        {
            InitializeComponent();
            ClassCB.ItemsSource = App.DB.classes.ToList();
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
            
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            classes cl = new classes();
            var Cl = App.DB.classes.Where(a => a.number == ClassCB.Text);
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
            computers com = new computers();
            try
            {
                com.idClass = cl.id;
                com.status = StatusChB.IsChecked;

            }
            catch
            {
                MessageBox.Show("Введён неверный формат");
                return;
            }
            
                App.DB.computers.Add(com);
                App.DB.SaveChanges();
                MessageBox.Show("Added!");
        }
    }
}
