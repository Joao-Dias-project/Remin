using Remin.Application.Services.Contracts.RepositoryContracts;
using Remin.Domain;

namespace Remin.Infra.Data.Repositories
{
    public class PhotoRepository : Repository<Photo, int>, IPhotoRepository
    {
        public PhotoRepository(ApplicationDbContext context) : base(context)
        {
            context.Photos
            .ToList();
        }
    }
}
