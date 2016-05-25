using EC.Domain.Entities.Vendas;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda, DataContext> , IVendaRepository
    {
        
    }
}