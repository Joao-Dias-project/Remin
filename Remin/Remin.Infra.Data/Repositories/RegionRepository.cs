using Remin.Domain;
using Remin.Application.Services.Contracts.RepositoryContracts;

namespace Remin.Infra.Data.Repositories
{
    public class RegionRepository : Repository<Region, int>, IRegionRepository
    {
        public RegionRepository(ApplicationDbContext context) : base(context)
        {
            context.Regions
            .ToList();
        }
    }
}
