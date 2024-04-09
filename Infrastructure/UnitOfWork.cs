using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Database;

namespace Infrastructure
{
    public class UnitOfWork(SQLDBContext SQLDBContext, IProductRepository productRepository) : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; } = productRepository;
        private readonly SQLDBContext _SQLDBContext = SQLDBContext;

        public async Task<int> SaveAsync() => await _SQLDBContext.SaveChangesAsync();

        public void Dispose()
        {
            _SQLDBContext.Dispose();
        }
    }
}
