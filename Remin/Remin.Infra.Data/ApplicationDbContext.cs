using Microsoft.EntityFrameworkCore;
using Remin.Domain;

namespace Remin.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RealtyAsset> RealtyAssets { get; set; }
        public DbSet<MediaLine> MediaLines { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaLine>().HasNoKey();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
