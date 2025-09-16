namespace E_CommerceBackend.Repository.IRepository
{
    public interface IFileRepository
    {
        Task<string> SaveFileAsync(IFormFile file, string subfolder);
    }
}
