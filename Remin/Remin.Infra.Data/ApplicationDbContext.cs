using Microsoft.EntityFrameworkCore;
using Remin.Domain;
using System.Reflection.Metadata;

namespace Remin.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RealtyAsset> RealtyAssets { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealtyAsset>()
                .HasMany(ra => ra.Photos)
                .WithOne()
                .HasForeignKey(p => p.RealtyAssetId)
                .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
