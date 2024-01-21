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
    /// Логика взаимодействия для AddClassP.xaml
    /// </summary>
    public partial class AddClassP : Page
    {
        public AddClassP()
        {
            InitializeComponent();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            classes cl = new classes();
            try
            {
                    cl.number = NumberTB.Text;
                    cl.seatCount = Convert.ToInt32(SeatTB.Text);
                    App.DB.classes.Add(cl);
                    App.DB.SaveChanges();
                    MessageBox.Show("Added!");
            }
            catch
            {
                MessageBox.Show("Error!");
            }

        }
    }
}
