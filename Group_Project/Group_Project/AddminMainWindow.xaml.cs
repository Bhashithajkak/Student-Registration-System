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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for AddminMainWindow.xaml
    /// </summary>
    public partial class AddminMainWindow : Window
    {
        public AddminMainWindow()
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
            if (txtUsername.Text == adminUsername && txtPassword.Password == adminPassword)
            {
                AdminLoggedWindow adminLoggedWindow = new AdminLoggedWindow();
                adminLoggedWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }


        private void BtnLoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {


            var window = new Group_Project.MainWindow();
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
