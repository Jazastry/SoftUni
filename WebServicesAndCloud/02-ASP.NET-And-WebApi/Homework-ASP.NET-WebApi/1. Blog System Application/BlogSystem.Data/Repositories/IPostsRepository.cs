using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        IQueryable<Post> AllPosts();

        IQueryable<Post> AllPostsByAutor(string username);
    }
}
