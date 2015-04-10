using BlogSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<User>, IBlogSystemDbContext
    {
        public BlogSystemDbContext()
            : base("BlogSystem", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemDbContext, BlogSystem.Data.Migrations.Configuration>());
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }
    }
}
