using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data;
using AdsData;

namespace _02_Play_With_ToList
{
    class Program
    {
        //Using Entity Framework select all ads from the database, then 
        //invoke ToList(), then filter the categories by status "Published", 
        //then select ad title, category and town, then invoke ToList() and finally
        //order the ads by publish date. Rewrite the same in more optimized way and
        //compare the performance.
        static void Main(string[] args)
        {
            var db = new AdsEntityes();

            var ads = db.Ads.ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .ToList();
            ads.ForEach(a => Console.WriteLine("{0} {1} {2}", a.Title == null ? "" : a.Title,
                a.AdCategory.Name == null ? "" : a.AdCategory.Name,
                a.Town.Name == null ? "" : a.Town.Name));
               
            db.Ads.Where(a => a.AdStatus.Status == "Published")
                .Select(a => a.Title + " " + a.AdCategory.Name + " " + a.Town.Name).ToList()
                .ForEach(a => Console.WriteLine(a));
        }
    }
}
