namespace BlogSystem.Data
{
    using System;

    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public interface IBlogSystemData
    {
        IUsersRepository Users { get; }

        IPostsRepository Posts { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
