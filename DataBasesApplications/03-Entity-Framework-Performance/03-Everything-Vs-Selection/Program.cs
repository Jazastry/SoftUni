using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data;
using AdsData;

namespace _03_Everything_Vs_Selection
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AdsEntityes();
            DateTime start = new DateTime();
            DateTime stop = new DateTime();

            start = DateTime.Now;
            var adsOne = db.Ads.ToList().Select(a => a.Title).ToList();
            adsOne.ForEach(a => Console.WriteLine(a));
            
            stop = DateTime.Now;

            var result = (start - stop);
            Console.WriteLine("\n RESULT 1 {0} \n", result);


            start = DateTime.Now;
            var adsTwo = db.Ads.Select(a => a.Title).ToList();
            adsTwo.ForEach(a => Console.WriteLine(a));
            stop = DateTime.Now;

            result = (start - stop);
            Console.WriteLine("\n RESULT 2 {0}", result);

        }
    }
}
