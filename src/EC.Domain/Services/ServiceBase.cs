using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public virtual void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public virtual void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            _repositoryBase.Remove(obj);
        }

        public virtual void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositoryBase.Find(predicate);
        }
    }
}