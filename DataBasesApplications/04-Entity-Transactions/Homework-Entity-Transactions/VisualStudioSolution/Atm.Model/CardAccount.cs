using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Atm.Model
{
    public class CardAccount
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string CardNumber { get; set; }
        [MaxLength(4)]
        public string CardPIN { get; set; }
        [ConcurrencyCheck]
        public decimal CardCash { get; set; }
    }
}
