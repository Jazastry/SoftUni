namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Resource
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public ResourceType TypeOfResource { get; set; }
       
        public string Link { get; set; }
    }
}
