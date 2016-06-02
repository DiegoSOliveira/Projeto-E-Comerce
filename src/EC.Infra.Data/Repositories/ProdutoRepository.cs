using System.Collections.Generic;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto> , IProdutoRepository
    {

    }
}