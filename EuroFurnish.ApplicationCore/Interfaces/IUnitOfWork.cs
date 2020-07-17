using EuroFurnish.ApplicationCore.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken=new CancellationToken());
    }
}
