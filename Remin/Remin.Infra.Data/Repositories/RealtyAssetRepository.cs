using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Remin.Application.Services.Contracts.RepositoryContracts;
using Remin.Domain;

namespace Remin.Infra.Data.Repositories
{
    public class RealtyAssetRepository : Repository<RealtyAsset, int>, IRealtyAssetRepository
    {
        public RealtyAssetRepository(ApplicationDbContext context) : base(context)
        {
            context.RealtyAssets
            .Include(ra => ra.Region)
            .Include(ra => ra.Photos)
            .ToList();
        }

        public async Task<RealtyAsset> CreateRealtyAsset(RealtyAsset entity)
        {
            var existingRegion = _context.ChangeTracker.Entries<Region>()
                                         .FirstOrDefault(e => e.Entity.Id == entity.Region.Id)?.Entity;
            if (existingRegion != null)
            {
                entity.Region = existingRegion;
            }
            else
            {
                _context.Entry(entity.Region).State = EntityState.Unchanged;
            }

            _context.RealtyAssets.Attach(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
