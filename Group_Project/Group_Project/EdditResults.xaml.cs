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
    /// Interaction logic for EdditResults.xaml
    /// </summary>
    public partial class EdditResults : Window
    {
        public EdditResults(EdditResultVM edditResultVM)
        {
            InitializeComponent();
            DataContext = edditResultVM;
            edditResultVM.CloseAction = new Action(this.Close);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Cancel(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
