using EC.Infra.Data.Interfaces;

namespace EC.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();

        void Commit();
    }
}