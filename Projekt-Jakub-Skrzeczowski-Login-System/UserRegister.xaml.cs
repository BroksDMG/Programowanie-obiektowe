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
using System.Windows.Shapes;

namespace Projekt_Jakub_Skrzeczowski_Login_System
{
    /// <summary>
    /// Logika interakcji dla klasy UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Window
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        public void LoginAcces()
        {
            UserLogin login = new UserLogin();

            login.Show();
        }
        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            LoginAcces();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;
            var Email = txtUsermail.Text;
            using (UserDataContext context =new UserDataContext())
            {
                
                    context.Users.Add(new User() { Name = Username, Password = Password, UserEmail = Email });
                    context.SaveChanges();
                    MessageBox.Show("you created an account");
                    LoginAcces();


            }
        }
    }
}
