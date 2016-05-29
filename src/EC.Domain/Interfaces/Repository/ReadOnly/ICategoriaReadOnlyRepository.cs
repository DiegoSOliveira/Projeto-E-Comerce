using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICategoriaReadOnlyRepository
    {
        Categoria GetByName(string nome);
        IEnumerable<Categoria> GetAll();
    }
}