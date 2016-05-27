using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EC.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity>  where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}