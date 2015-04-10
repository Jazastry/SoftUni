﻿namespace BlogSystem.Data
{
    using System;
    using System.Collections.Generic;

    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public class BlogSystemData : IBlogSystemData
    {
        private IBlogSystemDbContext context;
        private IDictionary<Type, object> repositories; 

        public BlogSystemData(IBlogSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IBlogSystemDbContext Context
        {
            get { return this.context; }
        }

        public IUsersRepository Users
        {
            get { return (IUsersRepository)this.GetRepository<User>(); }
        }

        public IPostsRepository Posts
        {
            get { return (IPostsRepository)this.GetRepository<Post>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                if (type.IsAssignableFrom(typeof(User)))
                {
                    repositoryType = typeof(UsersRepository);
                }
                if (type.IsAssignableFrom(typeof(Post)))
                {
                    repositoryType = typeof(PostsRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(repositoryType, this.context));
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
