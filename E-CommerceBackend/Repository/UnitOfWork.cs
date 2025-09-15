using E_CommerceBackend.Data;
using E_CommerceBackend.Repository.IRepository;

namespace E_CommerceBackend.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _sqldb;
        public ICategoryRepository Categories {  get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(SqlDbContext sqlDb)
        {
            _sqldb = sqlDb;
            Categories = new CategoryRepository(_sqldb);
            Products = new ProductRepository(_sqldb);
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
