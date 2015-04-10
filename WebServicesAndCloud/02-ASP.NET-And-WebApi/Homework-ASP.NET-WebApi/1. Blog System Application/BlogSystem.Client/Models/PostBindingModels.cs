using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using BlogSystem.Models;

namespace BlogSystem.Client.Models
{
    public class PostBindingModels
    {
        public class PostBindingModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
            [DataType(DataType.MultilineText)]
            [Display(Name = "Content")]
            public string Content { get; set; }

            public int Id { get; set; }

            public string UserId { get; set; }
        }
    }
}