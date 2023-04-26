using Microsoft.EntityFrameworkCore;
using Cine.Shared.Entities;


namespace Cine.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Colombia> Colombia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colombia>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
