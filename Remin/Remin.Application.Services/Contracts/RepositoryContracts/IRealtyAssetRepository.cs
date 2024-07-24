using Remin.Domain;

namespace Remin.Application.Services.Contracts.RepositoryContracts
{
    public interface IRealtyAssetRepository : IRepository<RealtyAsset, int>
    {
        Task<RealtyAsset> CreateRealtyAsset(RealtyAsset entity);
    }
}
