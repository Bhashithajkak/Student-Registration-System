using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Model
{
    public class Student
    {
        [Key]


        public string? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }

        public Student(string? studentId, string? firstName, string? lastName, string? gender, string? address, int age, string dateOfBirth)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Address = address;
            Age = age;
            DateOfBirth = dateOfBirth;
        }

        public Student()
        {
        }

    }
}