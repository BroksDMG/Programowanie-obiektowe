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

namespace Projekt_Jakub_Skrzeczowski_Login_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserLogin: Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {

        }






        public void GrandAcces()
        {
            MainPages main = new MainPages();
        
            main.Show();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;


            using(UserDataContext contex = new UserDataContext())
            {
                bool userdound = contex.Users.Any(user => user.Name == Username && user.Password == Password);
                if (userdound)
                {
                    GrandAcces();
                    Close();
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }

        }
    }
}
