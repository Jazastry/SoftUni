using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewsDb.Model
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string NewsContent { get; set; }
    }
}
