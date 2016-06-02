using EC.Infra.Data.Context;

namespace EC.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        DataContext GetContext();
    }
}