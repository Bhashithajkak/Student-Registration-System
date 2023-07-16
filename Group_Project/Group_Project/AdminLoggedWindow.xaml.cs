using Group_Project.ViewModel;
using Group_Project;
using Group_Project.ViewModel;
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
    /// Interaction logic for AdminLoggedWindow.xaml
    /// </summary>
    public partial class AdminLoggedWindow : Window
    {
        public AdminLoggedWindow()
        {


            InitializeComponent();
            DataContext = new AdminLoggedVM();

        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;


        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnLoginAsAdmin1_Click(object sender, RoutedEventArgs e)
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







        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackToLoggin_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();

        }
    }
}
