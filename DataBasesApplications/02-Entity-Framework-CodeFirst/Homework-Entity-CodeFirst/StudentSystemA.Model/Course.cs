namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Resource> resources;
        private ICollection<Homework> homeworkSubmissions;        
        public Course()
        {
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
            this.HomeworkSubmisions = new HashSet<Homework>();
        }        

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(5)]
        public string Description { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
     
        public DateTime? EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Student> Stidents
        {
            get { return this.students; }
            set { this.students = value; }
        }
        public virtual ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public virtual ICollection<Homework> HomeworkSubmisions
        {
            get { return this.homeworkSubmissions; }
            set { this.homeworkSubmissions = value; }
        }
    }
}
