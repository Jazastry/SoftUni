using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data;
using AdsData;

namespace _01_ShowData_From_Related_Tables
{
    class Program
    {
        static void Main()
        {
            var db = new AdsEntityes();

            var ads = db.Ads;

            foreach (var ad in ads.ToList())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    ad.Title == null ? "" : ad.Title,
                    ad.AdStatus.Status == null ? "" : ad.AdStatus.Status,
                    ad.AdCategory.Name == null ? "" : ad.AdCategory.Name,
                    ad.Town.Name == null ? "" : ad.Town.Name,
                    ad.AspNetUser.Name == null ? "" : ad.AspNetUser.Name);
            }

            db.Ads.Include(ast => ast.AdStatus.Status)
                    .Include(ac => ac.AdCategory.Name)
                    .Include(at => at.Town.Name)
                    .Include(au => au.AspNetUser.Name)
                    .ToList()
                    .ForEach(a => Console.WriteLine(a.Title + " "
                    + a.AdStatus.Status + " " + a.AdCategory.Name + " " + a.Town.Name + " " + a.AspNetUser.Name));

            var add = db.Ads.Select(a => a.Title + " "
                + a.AdStatus.Status + " " + a.AdCategory.Name + " " + a.Town.Name + " " + a.AspNetUser.Name)
                .ToList();
            add.ForEach(ad => Console.WriteLine(ad));
        }
    }
}
