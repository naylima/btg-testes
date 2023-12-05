using Microsoft.EntityFrameworkCore;
using src.Web.Api.Infrastructure.EntityFramework.Entity;

namespace src.Web.Api.Infrastructure.EntityFramework
{
    public class ResistenceDbContext : DbContext
    {
        public DbSet<Rebel> Rebels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public ResistenceDbContext(DbContextOptions<ResistenceDbContext> options) : base(options) {}
        public ResistenceDbContext() { }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rebel>()
                .HasOne<Location>(r => r.Location)
                .WithOne(l => l.Rebel)
                .IsRequired();

            modelBuilder.Entity<Rebel>()
                .HasMany<Inventory>(r => r.Inventories)
                .WithOne(l => l.Rebel)
                .IsRequired();
        }
    }
}