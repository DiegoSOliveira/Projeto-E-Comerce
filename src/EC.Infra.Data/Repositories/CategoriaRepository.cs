using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, DataContext> , ICategoriaRepository
    {

    }
}