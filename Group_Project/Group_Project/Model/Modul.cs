using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Group_Project.Model
{
    public class Modul
    {


        [Key]
        public string Student_Id { get; set; }
        public string? GuiProgramming { get; set; }
        public string? ProgramingProject { get; set; }
        public string? Electrical_and_Measurement { get; set; }
        public string? DataStuctures { get; set; }
        public string? SignalsAndSystems { get; set; }
        public string? AnalogElectronics { get; set; }
        public double Gpa { get; set; }

       

        public Modul(string student_Id, string? guiProgramming, string? programingProject, string? electrical_and_Measurement, string? dataStuctures, string? signalsAndSystems, string? analogElectronics, double gpa)
        {
            Student_Id = student_Id;
            GuiProgramming = guiProgramming;
            ProgramingProject = programingProject;
            Electrical_and_Measurement = electrical_and_Measurement;
            DataStuctures = dataStuctures;
            SignalsAndSystems = signalsAndSystems;
            AnalogElectronics = analogElectronics;
            Gpa = gpa;
        }
    }
}