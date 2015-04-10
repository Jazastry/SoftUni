namespace MusicSystem.Client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArtistCreationBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public string BirthDay { get; set; }
    }

    public class ArtistUpdateBindingModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}