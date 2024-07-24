namespace Remin.Application.Services.Contracts.ServiceContracts
{
    public interface IService<TEntity, TPrimaryKey>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Retrieve(TPrimaryKey pk);
        Task<List<TEntity>> RetrieveAll();
        Task<TEntity> Update(TEntity entity, TPrimaryKey pk);
        Task<TEntity> Delete(TPrimaryKey pk);
    }
}
