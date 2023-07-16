using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project.ViewModel;
using Group_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace Group_Project.ViewModel
{

    public partial class AdminLoggedVM : INotifyPropertyChanged
    {

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public AdminLoggedVM()
        {
            // Initialize the Users collection
            using (var context = new DataContext())
            {
                Users = new ObservableCollection<User>(context.users.ToList());
            }
        }

        // Implement the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private ObservableCollection<User> _users;

        //public ObservableCollection<User> Users
        //{
        //    get => _users;
        //    set => SetProperty(ref _users, value);
        //}

        //public User selectedUser = null;
        //public AdminLoggedVM()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        // Query the database for users and convert the result to an ObservableCollection
        //        Users = new ObservableCollection<User>(context.users.ToList());

        //    }
        //}

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        [RelayCommand]
        public void Delete_user()
        {
            using (DataContext context = new DataContext())
            {
                if (SelectedUser != null)
                {
                    MessageBox.Show($"{SelectedUser.UserName} is successfully Deleted..!");
                    context.users.Remove(SelectedUser);
                    context.SaveChanges();
                    Users.Remove(SelectedUser);

                }

                else
                {
                    

                    MessageBox.Show("Plese Select User to Delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }
        [RelayCommand]
        public void AddUser()
        {
            User newUser = new User();
            var vm = new AddUserVM(newUser);
            vm.Title = "Add New User";
            var adduserW = new AddUser(vm);
            adduserW.ShowDialog();

            if (vm.IsSaved)
            {
                Users.Add(vm.User);
                using (DataContext context = new DataContext())
                {
                    context.Add(vm.User);
                    context.SaveChanges();
                }
            }



        }

        [RelayCommand]
        public void ModifyUser()
        {
            if (SelectedUser != null)
            {
                var vm = new AddUserVM(SelectedUser);
                vm.Title = "Modify User Details";
                var modifyuserW = new AddUser(vm);
                modifyuserW.ShowDialog();

                if (vm.IsSaved)
                {
                    using (DataContext context = new DataContext())
                    {
                        var userToUpdate = context.users.FirstOrDefault(u => u.UserID == SelectedUser.UserID);
                        if (userToUpdate != null)
                        {
                            // Update the properties of the user
                            userToUpdate.UserName = vm.UserName;
                            userToUpdate.Password = vm.password;
                            // ...

                            context.SaveChanges();
                        }

                    }
                    int index = Users.IndexOf(SelectedUser);
                    Users.RemoveAt(index);
                    Users.Insert(index, vm.User);
                }
            }
            else
            {
                
                MessageBox.Show("Plese Select User to Modify.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
