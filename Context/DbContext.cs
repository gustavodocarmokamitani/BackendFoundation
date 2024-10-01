using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Usuario>().ToTable("Usuario"); 
        }
    }
}
