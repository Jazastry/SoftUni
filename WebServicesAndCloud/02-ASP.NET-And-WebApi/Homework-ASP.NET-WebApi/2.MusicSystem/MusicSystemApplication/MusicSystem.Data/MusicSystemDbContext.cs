namespace MusicSystem.Data
{
    using System.Data.Entity;
    using Model;

    public class MusicSystemDbContext : DbContext
    {
        public MusicSystemDbContext()
            : base ("MusicSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, MusicSystem.Data.Migrations.Configuration>());
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public static MusicSystemDbContext Create()
        {
            return new MusicSystemDbContext();
        }
    }
}
