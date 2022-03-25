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

        public DbSet<Menu> Menus { get; set; } // TODO: REMOVE
        
        public DbSet<SubMenu> SubMenus { get; set; } // TODO: REMOVE

        public DbSet<Reservation> Reservations { get; set; } // TODO: REMOVE

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>() 
                .Property(f => f.Id)
                .ValueGeneratedOnAdd(); // TODO: REMOVE
            
            modelBuilder.Entity<SubMenu>() 
                .Property(f => f.Id)
                .ValueGeneratedOnAdd(); // TODO: REMOVE
            
            modelBuilder.Entity<Reservation>() 
                .Property(f => f.Id)
                .ValueGeneratedOnAdd(); // TODO: REMOVE
        }
    }
}