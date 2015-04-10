namespace BlogSystem.Data.Repositories
{
    using System.Linq;

    using BlogSystem.Models;
using System;
    using System.Collections.Generic;

    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(IBlogSystemDbContext context) 
            : base(context)
        {
        }

        public IQueryable<User> AllAuthors()
        {
            return this.All().Where(x => x.Posts.Any());
        }

        public IQueryable<User> AllByGender(Gender gender)
        {
            return this.All().Where(x => x.Gender == gender);
        }

        public User GetUserByUsername(string username)
        {
            return this.All().Where(x => x.UserName == username).FirstOrDefault();
        }

        public void CreateUser(string userName, DateTime birthDay, Gender gender)
        {
            this.DbSet.Add(new User() { UserName = userName, Birthday = birthDay, Gender = gender });            
        }
    }
}
