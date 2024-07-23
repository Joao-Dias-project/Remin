namespace Remin.Application.Services.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        bool HasChanges();
    }
}
