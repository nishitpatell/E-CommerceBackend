using E_CommerceBackend.Data;
using E_CommerceBackend.Repository.IRepository;

namespace E_CommerceBackend.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _sqldb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ICategoryRepository Categories {  get; private set; }
        public IProductRepository Products { get; private set; }
        public IFileRepository Files { get; private set; }

        public UnitOfWork(SqlDbContext sqlDb, IWebHostEnvironment webHostEnvironment)
        {
            _sqldb = sqlDb;
            _webHostEnvironment = webHostEnvironment;

            Categories = new CategoryRepository(_sqldb);
            Products = new ProductRepository(_sqldb);
            Files = new FileRepository(_webHostEnvironment);
        }

        public Task<int> SaveAsync()
        {
            return _sqldb.SaveChangesAsync();
        }

        public void Dispose()
        {
            _sqldb.Dispose();
        }
    }
}
