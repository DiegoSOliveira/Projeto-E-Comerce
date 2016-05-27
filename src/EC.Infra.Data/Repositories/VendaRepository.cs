using System.Data.Entity;
using EC.Domain.Entities.Vendas;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda, DataContext> , IVendaRepository
    {
        public override void Add(Venda venda)
        {
            Context.Set<Venda>().Add(venda);
            foreach (var produto in venda.ProdutosList)
            {
                Context.Entry(produto).State = EntityState.Unchanged;
            }
        }
    }
}