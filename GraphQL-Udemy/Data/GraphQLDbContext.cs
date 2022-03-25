using GraphQL_Udemy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GraphQL_Udemy.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; } // TODO: Remove

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>() // TODO: Remove
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Song>()
                .Property(f => f.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Artist>()
                .Property(f => f.Artist_ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Album>()
                .Property(f => f.Album_ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Genre>()
                .Property(f => f.Genre_ID)
                .ValueGeneratedOnAdd();
        }
    }
}