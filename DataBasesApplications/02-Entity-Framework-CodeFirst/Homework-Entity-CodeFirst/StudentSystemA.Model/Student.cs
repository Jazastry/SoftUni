namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Student
    {
        private ICollection<Course> courses;
        public Student()
        {
            this.courses = new HashSet<Course>();
        }
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }        
        public DateTime? RegistrationDate { get; set; }
        public DateTime? BirthDay { get; set; }        
        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
