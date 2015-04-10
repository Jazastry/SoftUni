namespace MusicSystem.Client.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class AlbumsGetBundingModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }

    public class AlbumsCreateBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Range(0,9999)]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Producer")]
        public string Producer { get; set; }
    }

    public class AlbumUpdateBindingModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Range(0, 9999)]
        [Display(Name = "Year")]
        public int? Year { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Producer")]
        public string Producer { get; set; }
    }
}