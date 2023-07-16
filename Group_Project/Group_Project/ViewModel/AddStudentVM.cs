using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Group_Project.ViewModel
{
    public partial class AddStudentVM : ObservableObject
    {
        [ObservableProperty]
        public string studentID;
        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public int age;
        [ObservableProperty]
        public string address;
        [ObservableProperty]
        public string gender;
        [ObservableProperty]
        public string dateOfBirth;

        public AddStudentVM(Student student)
        {
            studentID = student.StudentId;
            firstName = student.FirstName;
            lastName = student.LastName;
            age = student.Age;
            address = student.Address;
            gender = student.Gender;
            dateOfBirth = student.DateOfBirth;
        }

        public AddStudentVM()
        {
        }

        public string Title { get; set; }




        public Student newStudent { get; set; }
        public Action CloseAction2 { get; set; }
        public bool IsSaved = false;

        private RelayCommand saveCommand;
        public ICommand SaveCommand => saveCommand ??= new RelayCommand(Save);

        private void Save()
        {
            if (studentID != null || firstName != null || lastName != null || age != null || address != null || dateOfBirth != null || gender != null)
            {
                newStudent = new Student(studentID, firstName, lastName, gender, address, age, dateOfBirth);
                IsSaved = true;
                CloseAction2();
            }
            else if (studentID != null)
            {
                MessageBox.Show("Invalid StudentID");

            }
            else if (firstName != null)
            {
                MessageBox.Show("Invalid FirstName");
            }
            else if (lastName != null)
            {
                MessageBox.Show("Invalid LastName");
            }
            else if (age != null)
            {
                MessageBox.Show("Invalid Age");
            }
            else if (gender != null)
            {
                MessageBox.Show("Invalid Gender");
            }
            else if (address != null)
            {
                MessageBox.Show("Invalid Address");
            }
            else
            {
                MessageBox.Show("Invalid Date OF Birth");
            }
        }
        //[RelayCommand]
        //public void Save()
        //{
        //    if (studentID != null || firstName != null || lastName != null|| age != null || address != null || dateOfBirth != null || gender!=null)
        //    {
        //        Student = new Student( studentID, firstName, lastName, gender, address, age, dateOfBirth);
        //        IsSaved = true;
        //        CloseAction1();
        //    }
        //    else if (studentID != null)
        //    {
        //        MessageBox.Show("Invalid StudentID");
        //    }
        //    else if (firstName != null)
        //    {
        //        MessageBox.Show("Invalid FirstName");
        //    }
        //    else if (lastName != null)
        //    {
        //        MessageBox.Show("Invalid LastName");
        //    }
        //    else if (age != null)
        //    {
        //        MessageBox.Show("Invalid Age");
        //    }
        //    else if (gender != null)
        //    {
        //        MessageBox.Show("Invalid Gender");
        //    }
        //    else if (address != null)
        //    {
        //        MessageBox.Show("Invalid Address");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid Date OF Birth");
        //    }
        //}



    }
}