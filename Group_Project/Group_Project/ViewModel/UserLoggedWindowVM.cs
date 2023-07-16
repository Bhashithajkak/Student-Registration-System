using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project.ViewModel;
using Group_Project;
using Group_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Group_Project.ViewModel
{
    public partial class UserLoggedWindowVM : INotifyPropertyChanged
    {
        // *********** Define the ObservableCollection *****************

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }



        //**********  Define default constructor as the Student ObservableCollection ********

        public UserLoggedWindowVM()
        {
            using (var context = new DataContext())
            {
                Students = new ObservableCollection<Student>(context.students.ToList());
            }
        }



        // **************** Define OnPropertychanged **************

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // ***************** Define selected student **************

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }



        //************** Delete selected student *************


        [RelayCommand]
        public void Delete_student()
        {
            using (DataContext context = new DataContext())
            {
                if (SelectedStudent != null)
                {
                    MessageBox.Show($"{SelectedStudent.StudentId} is successfully Deleted..!");
                    context.students.Remove(SelectedStudent);
                    context.SaveChanges();
                    Students.Remove(SelectedStudent);
                }

                else
                {
                   
                    MessageBox.Show("Plese Select Student before Delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        // ************** Add new student*************************

        [RelayCommand]
        public void AddStudent()
        {
            Student newStudent = new Student();
            var vm = new AddStudentVM(newStudent);
            vm.Title = "Add New Student";
            var addStudentW = new AddStudent(vm);
            addStudentW.ShowDialog();

            if (vm.IsSaved)
            {
                Students.Add(vm.newStudent);
                using (DataContext context = new DataContext())
                {
                    context.Add(vm.newStudent);
                    context.SaveChanges();
                }

            }
        }


        //************ Modify selected student *********
        [RelayCommand]
        public void ModifyStudent()
        {
            if (SelectedStudent != null)
            {
                var vm = new AddStudentVM(SelectedStudent);
                vm.Title = "Modify Student Details";
                var modifystudentW = new AddStudent(vm);
                modifystudentW.ShowDialog();

                if (vm.IsSaved)
                {
                    using (DataContext context = new DataContext())
                    {
                        var studentToUpdate = context.students.FirstOrDefault(u => u.StudentId == SelectedStudent.StudentId);
                        if (studentToUpdate != null)
                        {
                            // Update the properties of the user
                            studentToUpdate.StudentId = SelectedStudent.StudentId;
                            studentToUpdate.FirstName = vm.firstName;
                            studentToUpdate.LastName = vm.lastName;
                            studentToUpdate.Address = vm.address;
                            studentToUpdate.Age = vm.age;
                            studentToUpdate.DateOfBirth = vm.dateOfBirth;
                            studentToUpdate.Gender = vm.gender;
                            // ...

                            context.SaveChanges();
                        }

                    }
                    int index = Students.IndexOf(SelectedStudent);
                    Students.RemoveAt(index);
                    Students.Insert(index, vm.newStudent);
                }
            }
            else
            {
                
                MessageBox.Show("Plese Select Student before Modify.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //*********** View Results *******************

        [RelayCommand]
        public void ViewResults()
        {
            if (SelectedStudent != null)
            {
                var modulesVM = new ModulesVM(SelectedStudent);
                var modulesW = new Moduels(modulesVM);
                modulesW.ShowDialog();
            }
            else
            {
                
                MessageBox.Show("Plese Select Student to view Result.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

