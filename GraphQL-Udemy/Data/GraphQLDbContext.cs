using GraphQL_Udemy.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Udemy.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}