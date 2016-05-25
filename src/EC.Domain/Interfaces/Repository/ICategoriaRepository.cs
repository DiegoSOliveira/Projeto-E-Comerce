using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Repository
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        IEnumerable<Produto> ObterCategoria(string nome);
    }
}