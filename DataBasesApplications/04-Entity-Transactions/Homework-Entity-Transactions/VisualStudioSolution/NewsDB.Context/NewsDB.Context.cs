using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NewsDb.Model;
using System.ComponentModel.DataAnnotations;

namespace NewsDb.Context
{
    
    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("NewsDb")
        { }
        [ConcurrencyCheck]
        public IDbSet<News> News { get; set; }
    }
}
