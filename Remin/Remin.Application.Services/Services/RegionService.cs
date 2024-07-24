using Remin.Application.Services.Contracts.RepositoryContracts;
using Remin.Application.Services.Contracts.ServiceContracts;
using Remin.Application.Services.Contracts;
using Remin.Domain;

namespace Remin.Application.Services.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RegionService(IRegionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Region> Create(Region entity)
        {
            var region = await _repository.Create(entity);
            await _unitOfWork.Commit();
            return region;
        }

        public async Task<Region> Delete(int pk)
        {
            var entity = await _repository.Delete(pk);
            await _unitOfWork.Commit();
            return entity;
        }

        public Task<Region> Retrieve(int pk)
        {
            return _repository.Retrieve(pk);
        }

        public Task<List<Region>> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public async Task<Region> Update(Region entity, int pk)
        {
            var region = _repository.Update(entity, pk);
            await _unitOfWork.Commit();
            return region;
        }
    }
}
