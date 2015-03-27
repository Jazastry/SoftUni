using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ChatRoom.Context
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }

        public virtual User User { get; set; }

        public DateTime Date { get; set; }
    }
}
