using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project;
using Group_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project.ViewModel
{
    public partial class EdditResultVM : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string studentId;
        [ObservableProperty]
        public string ee1;
        [ObservableProperty]
        public string ee2;
        [ObservableProperty]
        public string ee3;
        [ObservableProperty]
        public string ee4;
        [ObservableProperty]
        public string ee5;
        [ObservableProperty]
        public string ee6;
        [ObservableProperty]
        public double gpa;

        public bool Is_save = false;

        public Action CloseAction { get; set; }

        public EdditResultVM()
        {
        }

        public EdditResultVM(Student studentTo)
        {
            Name = studentTo.FirstName;
            StudentId = studentTo.StudentId;
            using (DataContext context = new DataContext())
            {
                var studentToVeiw = context.modules.FirstOrDefault(s => s.Student_Id == studentId);
                if (studentToVeiw != null)
                {

                    Ee1 = studentToVeiw.GuiProgramming;
                    Ee2 = studentToVeiw.ProgramingProject;
                    Ee3 = studentToVeiw.Electrical_and_Measurement;
                    Ee4 = studentToVeiw.DataStuctures;
                    Ee5 = studentToVeiw.SignalsAndSystems;
                    Ee6 = studentToVeiw.AnalogElectronics;
                    Gpa = studentToVeiw.Gpa;
                }

            }
        }

        [RelayCommand]
        public void Save()
        {
            Is_save = true;
            CloseAction();
        }
    }
}