namespace BlogSystem.Data.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using BlogSystem.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public sealed class Configuration : DbMigrationsConfiguration<BlogSystem.Data.BlogSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogSystemDbContext context)
        {
            
            if (!context.Users.Any())
            {
                User userOne = new User()
                {
                    UserName = "First User",
                    PasswordHash = "AB0Hz+jvMZYq1/5xea60ta6/9Rf4MWhGtrZyy2dMzvMD+qMbxa21In1vzr51BGGySQ==",          
                    PhoneNumber = "123151",
                    Gender = Gender.Other,
                    RegistrationDate = DateTime.Now,
                    ContactInfo = new UserContactInfo()
                        {
                            PhoneNumber = "123151",
                            Skype = "Jjoj",
                            Facebook = "JOjojoj",
                            Tweeter = "TwiTwi"
                        }
                };
                context.Users.Add(userOne);
                User userTwo = new User()
                {
                    UserName = "Secund User",
                    PasswordHash = "AB0Hz+jvMZYq1/5xea60ta6/9Rf4MWhGtrZyy2dMzvMD+qMbxa21In1vzr51BGGySQ==",
                    PhoneNumber = "123151",
                    Gender = Gender.Other,
                    RegistrationDate = DateTime.Now,
                    ContactInfo = new UserContactInfo()
                    {
                        PhoneNumber = "123151",
                        Skype = "Jjoj",
                        Facebook = "JOjojoj",
                        Tweeter = "TwiTwi"
                    }
                };
                context.Users.Add(userTwo);

                Tag tagOne = new Tag(){Name = "Tag One"};
                Tag tagTwo = new Tag(){Name = "Tag Two"};
                Tag tagThree = new Tag(){Name = "Tag Three"};
                context.Tags.Add(tagOne);
                context.Tags.Add(tagTwo);
                context.Tags.Add(tagThree);

                Post postOne = new Post()
                {
                    User = userOne,
                    Title = "The Post One",
                    Tags = new List<Tag>() { tagOne, tagTwo, tagThree },
                    Content = "The content of the first Post."                    
                };
                Post postTwo = new Post()
                {
                    User = userTwo,
                    Title = "The Post Two",
                    Tags = new List<Tag>() { tagOne, tagTwo, tagThree },
                    Content = "The content of the second Post."
                };
                Post postThree = new Post()
                {
                    User = userOne,
                    Title = "The Post Three",
                    Tags = new List<Tag>() { tagOne, tagTwo, tagThree },
                    Content = "The content of the fithird Post."
                };
                context.Posts.Add(postOne);
                context.Posts.Add(postTwo);
                context.Posts.Add(postThree);
             
                context.SaveChanges();
            }
        }
    }
}
