using Remin.Application.Services.Contracts.RepositoryContracts;
using Remin.Application.Services.Contracts;
using Remin.Application.Services.Contracts.ServiceContracts;
using Remin.Domain;

namespace Remin.Application.Services.Services
{
    public class RealtyAssetService : IRealtyAssetService
    {
        private readonly IRealtyAssetRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RealtyAssetService(IRealtyAssetRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RealtyAsset> Create(RealtyAsset entity)
        {
            var realtyAsset = await _repository.CreateRealtyAsset(entity);
            await _unitOfWork.Commit();
            return realtyAsset;
        }

        public async Task<RealtyAsset> Delete(int pk)
        {
            var entity = await _repository.Delete(pk);
            await _unitOfWork.Commit();
            return entity;
        }

        public Task<RealtyAsset> Retrieve(int pk)
        {
            return _repository.Retrieve(pk);
        }

        public Task<List<RealtyAsset>> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public async Task<RealtyAsset> Update(RealtyAsset entity, int pk)
        {
            var realtyAsset = _repository.Update(entity, pk);
            await _unitOfWork.Commit();
            return realtyAsset;
        }
    }
}
