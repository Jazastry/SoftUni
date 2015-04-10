using System.Collections;
using System.Collections.Generic;

namespace MusicSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
