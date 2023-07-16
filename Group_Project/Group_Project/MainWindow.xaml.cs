
using Group_Project;
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

using System.Reflection.Metadata;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private const string adminUsername = "Admin";
        private const string adminPassword = "12345";
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                if (context.users.Any(u => txtUsername.Text == u.UserName && txtPassword.Password == u.Password) || txtUsername.Text == adminUsername && txtPassword.Password == adminPassword)
                {
                   UserLoggedWindow userLoggedWindow = new UserLoggedWindow();
                    userLoggedWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }

        }

        private void BtnLoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {


            var window = new Group_Project.AddminMainWindow();
            window.Show();
            this.Close();

            // if (txtUsername.Text == adminUsername && txtPassword.Password == adminPassword)
            //{
            //  AdminLoggedWindow adminLoggedWindow = new AdminLoggedWindow();
            //adminLoggedWindow.Show();
            //this.Close();
            // }
            //else
            //{
            //  MessageBox.Show("Invalid Username or Password");
            //}

        }
    }
}
