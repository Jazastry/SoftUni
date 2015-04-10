using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Repositories
{
    public class PostsRepository : GenericRepository<Post>, IPostsRepository
    {
        public PostsRepository(IBlogSystemDbContext context)
            : base (context)
        {
        }

        public IQueryable<Post> AllPostsByAutor(string username)
        {
            return this.All().Where(p => p.User.UserName == username);
        }

        public Post PostsById(int id)
        {
            return this.All().Where(p => p.Id == id).FirstOrDefault();
        }

        public IQueryable<Post> AllPosts()
        {
            return this.All();
        }
    }
}
