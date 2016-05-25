using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EC.Infra.Data.Interfaces
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T Entity) where T : class;
        int SaveChanges();
        void Dispose();
    }
}