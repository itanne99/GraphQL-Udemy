using GraphQL_Udemy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

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
        
        public DbSet<Log> Logs { get; set; }

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
            
            modelBuilder.Entity<Log>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }
        
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseNpgsql("Host=localhost; Database=graphQL; Username=JimmyCricket; Password=AppleBombs4152");
    }
}