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
using MaterialDesignThemes.Wpf;

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
       
        
        public void RegisterAcces()
        {
            UserRegister register = new UserRegister();
            register.Show();
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
            var Email = txtUsername.Text;


            using(UserDataContext contex = new UserDataContext())
            {
                bool userfound = contex.Users.Any(user => (user.Name == Username && user.Password == Password)||(user.UserEmail==Email&&user.Password==Password));
                if (userfound)
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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterAcces();
            Close();
        }
    }
}
