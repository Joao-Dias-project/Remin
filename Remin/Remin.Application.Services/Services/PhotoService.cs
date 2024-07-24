using Remin.Application.Services.Contracts.RepositoryContracts;
using Remin.Application.Services.Contracts.ServiceContracts;
using Remin.Application.Services.Contracts;
using Remin.Domain;

namespace Remin.Application.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PhotoService(IPhotoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Photo> Create(Photo entity)
        {
            var photo = await _repository.Create(entity);
            await _unitOfWork.Commit();
            return photo;
        }

        public async Task<Photo> Delete(int pk)
        {
            var entity = await _repository.Delete(pk);
            await _unitOfWork.Commit();
            return entity;
        }

        public Task<Photo> Retrieve(int pk)
        {
            return _repository.Retrieve(pk);
        }

        public Task<List<Photo>> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public async Task<Photo> Update(Photo entity, int pk)
        {
            var photo = _repository.Update(entity, pk);
            await _unitOfWork.Commit();
            return photo;
        }
    }
}
