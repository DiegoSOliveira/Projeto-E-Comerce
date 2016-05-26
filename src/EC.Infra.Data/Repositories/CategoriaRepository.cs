using System.Collections.Generic;
using System.Linq;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, DataContext> , ICategoriaRepository
    {
        //public IEnumerable<Produto> ObterCategoria(string nome)
        //{
        //    var categoria = Find(c => c.Nome == nome).FirstOrDefault();
        //    return categoria.Produtos;
        //}
    }
}