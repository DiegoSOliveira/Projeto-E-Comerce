using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> GetByName(string nome);
    }
}