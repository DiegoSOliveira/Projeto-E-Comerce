using EC.Infra.Data.Interfaces;

namespace EC.Application.Interfaces
{
    public interface IAppServiceBase
    {
        void BeginTransaction();

        void Commit();
    }
}