namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Homework
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        [MinLength(10)]
        public string Content { get; set; }
        public ContentType ContentType{ get; set; } 
             
        public DateTime? HomeworkDate { get; set; }
        public virtual Student SubmissionStudent { get; set; }
    }
}
