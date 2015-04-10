namespace MusicSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public Song()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public int Year { get; set; }

        public string Genere { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public virtual ICollection<Album> Albums { get; set; } 
    }
}
