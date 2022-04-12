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

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Genre>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Artist>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Song>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
    }
}