using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.Model;
using Group_Project.ViewModel;
using Group_Project;
using Group_Project.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project.ViewModel
{
    public partial class ModulesVM : ObservableObject
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
        public Student StudentReg { get; set; }



        public Action CloseAation1 { get; set; }

        public ModulesVM()
        {
        }

        public ModulesVM(Student studentTo)
        {
            StudentReg = studentTo;
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
                else
                {
                    MessageBox.Show("Results Not Awaleble for selected student");
                    Ee1 = "NA";
                    Ee2 = "NA";
                    Ee3 = "NA";
                    Ee4 = "NA";
                    Ee5 = "NA";
                    Ee6 = "NA";
                    Gpa = 0;
                }
            }


        }

        [RelayCommand]
        public void Eddit_Results()
        {
            CloseAation1();
            var EdditresultsVM = new EdditResultVM(StudentReg);
            var EdditResultsW = new EdditResults(EdditresultsVM);
            EdditResultsW.ShowDialog();
            if (EdditresultsVM.Is_save == true)
            {
                StudentId = StudentReg.StudentId;
                using (DataContext context = new DataContext())
                {
                    var studentToEddit = context.modules.FirstOrDefault(s => s.Student_Id == studentId);
                    if (studentToEddit != null)
                    {

                        
                        studentToEddit.GuiProgramming = EdditresultsVM.Ee1;
                        studentToEddit.ProgramingProject = EdditresultsVM.Ee2;
                        studentToEddit.Electrical_and_Measurement = EdditresultsVM.Ee3;
                        studentToEddit.DataStuctures = EdditresultsVM.Ee4;
                        studentToEddit.SignalsAndSystems = EdditresultsVM.Ee5;
                        studentToEddit.AnalogElectronics = EdditresultsVM.Ee6;
                        
                        studentToEddit.Gpa = GpaCalculate(studentToEddit.DataStuctures, studentToEddit.ProgramingProject, studentToEddit.Electrical_and_Measurement, studentToEddit.SignalsAndSystems, studentToEddit.AnalogElectronics, studentToEddit.GuiProgramming);
                        context.SaveChanges();

                    }
                    else
                    {
                        EdditresultsVM.gpa = GpaCalculate(EdditresultsVM.Ee1, EdditresultsVM.Ee2, EdditresultsVM.Ee3, EdditresultsVM.Ee4, EdditresultsVM.Ee5, EdditresultsVM.Ee6);

                        Modul resultToAdd = new Modul(studentId, EdditresultsVM.Ee1,EdditresultsVM.Ee2,EdditresultsVM.Ee3,EdditresultsVM.Ee4,EdditresultsVM.Ee5,EdditresultsVM.Ee6,EdditresultsVM.gpa);
                        context.Add(resultToAdd);

                        context.SaveChanges();


                    }
                }
            }

        }

        public double GpaCalculate(string EE1,string EE2, string EE3,string EE5, string EE4, string EE6)
        {
            double Gpa = (CalGpaFromM(EE1) * 2 + CalGpaFromM(EE2) * 2 + CalGpaFromM(EE3) * 2 + CalGpaFromM(EE4) * 3 + CalGpaFromM(EE5) * 3 + CalGpaFromM(EE6) * 3) / 15;
            
            return Math.Round(Gpa, 3); ;
        }

        public double CalGpaFromM(string grade)
        {
            double GpaFromM = 0;
            if (grade == "A+"|| grade == "A")
            { 
                GpaFromM = 4;
            }
            else if(grade == "A-")
            {
                GpaFromM=3.7;
            }
            else if (grade == "B+")
            {
                GpaFromM = 3.3;
            }
            else if (grade == "B")
            {
                GpaFromM = 3.0;

            }
            else if (grade == "B-")
            {
                GpaFromM = 2.7;
            }
            else if (grade == "C+")
            {
                GpaFromM = 2.3;
            }
            else if (grade == "A-")
            {
                GpaFromM = 2.0;
            }
            else if (grade == "A-")
            {
                GpaFromM = 1.7;
            }
            else
            {
                GpaFromM = 0;
            }
            return GpaFromM;
        }
    }
}
