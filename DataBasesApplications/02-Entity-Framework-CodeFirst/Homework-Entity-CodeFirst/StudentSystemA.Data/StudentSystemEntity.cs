using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using StudentSystem.Model;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data
{
    public class StudentSystemDBContext : DbContext
    {
        public StudentSystemDBContext() : base("StudentSystem") 
        { 
        }        
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }     
    }       
}
