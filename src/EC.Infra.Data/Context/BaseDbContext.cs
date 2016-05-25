using System.Data.Entity;
using EC.Infra.Data.Interfaces;

namespace EC.Infra.Data.Context
{
    public class BaseDbContext : DbContext , IDbContext
    {
        public BaseDbContext(string connectionString) : base(connectionString)
        {
                
        }
        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}