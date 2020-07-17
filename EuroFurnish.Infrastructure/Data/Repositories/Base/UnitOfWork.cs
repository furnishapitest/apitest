using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;
using EuroFurnish.ApplicationCore.Interfaces.Repositories;
using EuroFurnish.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EuroFurnish.Infrastructure.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        #region IOC-Repositories
        public ICategoryRepository CategoryRepository => HttpHelper.GetService<ICategoryRepository>();

        public IUserRepository UserRepository => HttpHelper.GetService<IUserRepository>();

        public IProductRepository ProductRepository => HttpHelper.GetService<IProductRepository>();
        #endregion


        #region Commits
        public int Commit()
        {
            var transId = -1;
            if (_context.ChangeTracker.HasChanges())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (_context != null)
                        {
                            transId = _context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return transId;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var transId = -1;
            if (_context.ChangeTracker.HasChanges())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (_context != null)
                        {
                            transId = await _context.SaveChangesAsync(cancellationToken);
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return transId;
        }
        #endregion

        #region Dispose
        private bool _disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    _context.Dispose();
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}
