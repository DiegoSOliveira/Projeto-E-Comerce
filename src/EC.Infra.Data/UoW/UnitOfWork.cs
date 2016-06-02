using System;
using EC.Infra.Data.Context;
using EC.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace EC.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
            _dbContext = contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}