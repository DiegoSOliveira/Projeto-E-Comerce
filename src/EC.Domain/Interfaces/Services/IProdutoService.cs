using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> GetByName(string nome);
    }
}