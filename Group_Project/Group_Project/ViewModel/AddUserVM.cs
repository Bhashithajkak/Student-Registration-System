using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project.ViewModel
{
    public partial class AddUserVM : ObservableObject
    {
        [ObservableProperty]
        public string userID;
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string password;


        public string Title { get; set; }


        public AddUserVM(User changingUser)
        {

            userID = changingUser.UserID;
            userName = changingUser.UserName;
            password = changingUser.Password;

        }
        public AddUserVM()
        {

        }
        public User User { get; set; }
        public Action CloseAction1 { get; set; }
        public bool IsSaved = false;

        [RelayCommand]
        public void Save()
        {
            if (userID != null || userName != null || password != null)
            {
                User = new User(userID, userName, password);
                IsSaved = true;
                CloseAction1();
            }
            else if (userID != null)
            {
                MessageBox.Show("Invalid UserID");
            }
            else if (userName != null)
            {
                MessageBox.Show("Invalid UserName");
            }
            else
            {
                MessageBox.Show("Invalid Passward");
            }
        }


    }
}
