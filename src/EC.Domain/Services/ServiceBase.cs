using System;
using System.Collections.Generic;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase )
        {
            _repositoryBase = repositoryBase;
        }
        public void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public TEntity GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repositoryBase.Remove(obj);
        }

        void IDisposable.Dispose()
        {
            _repositoryBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}