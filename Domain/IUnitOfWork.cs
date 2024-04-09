using Domain.Interfaces.Repositories;

namespace Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; set; }

        Task<int> SaveAsync();
    }
}

