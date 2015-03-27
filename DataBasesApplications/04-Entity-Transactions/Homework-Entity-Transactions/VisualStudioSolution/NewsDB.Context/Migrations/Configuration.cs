namespace NewsDb.Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using NewsDb.Context;
    using NewsDb.Model;

    public sealed class Configuration : DbMigrationsConfiguration<NewsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NewsDb.Context.NewsDbContext";
        }

        protected override void Seed(NewsDbContext context)
        {
            List<News> news = new List<News>()
            {
               new News(){ NewsContent = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."},
               new News(){ NewsContent = " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."},
               new News(){ NewsContent = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
               new News(){ NewsContent = "Libero inventore maiores accusamus, a asperiores ullam beatae quaerat. Labore expedita magni quis eos velit saepe autem iure rem ducimus. Et eum tenetur sed."},
               new News(){ NewsContent = "The very interesting news."},
               new News(){ NewsContent = "Repellendus rerum voluptatum ducimus, aliquam.</span><span>Ex quaerat vitae aliquam, eligendi laborum."},
               new News(){ NewsContent = "Irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
            };

            news.ForEach(delegate(News n)
            {
                if (!context.News.Any(ne => ne.NewsContent == n.NewsContent))
                {
                    context.News.Add(n);
                }
            });

            //news.ForEach(n => context.News.Add(n));

            context.SaveChanges();
        }
    }
}
