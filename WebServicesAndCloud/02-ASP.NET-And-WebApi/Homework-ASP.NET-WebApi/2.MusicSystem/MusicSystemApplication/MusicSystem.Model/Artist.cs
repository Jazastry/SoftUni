using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSystem.Model
{
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Song> Songs { get; set; } 
    }
}
