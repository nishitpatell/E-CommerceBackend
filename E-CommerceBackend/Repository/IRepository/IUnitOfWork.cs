namespace E_CommerceBackend.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IFileRepository Files { get; }
        Task<int> SaveAsync();
    }
}
