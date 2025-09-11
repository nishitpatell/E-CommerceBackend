namespace E_CommerceBackend.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }

        Task<int> SaveAsync();
    }
}
