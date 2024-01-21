using Microsoft.Win32;
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
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        static class nameUs
        {
            public static string DATA { get; set; }
        }
        public LoginP()
        {
            InitializeComponent();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterP());
        }

        private void SignInBTN_Click(object sender, RoutedEventArgs e)
        {

            var user = App.DB.users.Where(a => a.login == loginTB.Text);
            if (user.Any() == true)
            {
                foreach (users us in user)
                {
                    if (us.password == PassTB.Text)
                    {
                        nameUs.DATA = us.name;
                        NavigationService.Navigate(new UserP());
                    }
                    else MessageBox.Show("Неверный пароль");
                }
            }
            else MessageBox.Show("Неверное имя пользователя");

        }
    }
}
