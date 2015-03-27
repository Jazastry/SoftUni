using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;

using NewsDb.Model;
using NewsDb.Context;
using NewsDb.Context.Migrations;


namespace NewsDb.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
            var context = new NewsDbContext();

            if (!context.News.Any())
            {
                News initialNews = new News() { NewsContent = " The Start News." };
                context.News.Add(initialNews);
                context.SaveChanges();
            }
            Console.WriteLine("Application started.");
            bool commitSuccess;

            do
            {
                commitSuccess = true;
                
                try
                {
                    ChangeFirstNewsContent(context);
                    context.SaveChanges();
                    commitSuccess = false;
                    Console.WriteLine("Changes successfully saved in the DB.");
                    Console.WriteLine("Press Enter to EXIT.");
                    Console.ReadLine();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Conflict!");
                    context = new NewsDbContext();
                }

            } while (commitSuccess);

        }

        private static void ChangeFirstNewsContent(NewsDbContext context)
        {
            var firstNews = context.News.FirstOrDefault();

            Console.WriteLine("Text form DB : {0}\n" +
                "Enter the corected text.\n" +
                "User Input : ", firstNews.NewsContent);

            var userInput = Console.ReadLine();

            firstNews.NewsContent = userInput;
        }
    }
}
