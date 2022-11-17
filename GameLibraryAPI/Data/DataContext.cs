using Microsoft.EntityFrameworkCore;

namespace GameLibraryAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Console> Consoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(ge => ge.Games)
                .WithOne(ga => ga.Genre)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
