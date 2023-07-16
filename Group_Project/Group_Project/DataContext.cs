using Group_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UserData.db");

            
        }

        public DbSet<User> users { get; set; }

        public DbSet<Student> students { get; set; }

        public DbSet<Modul> modules { get; set; }



    }

   
}
