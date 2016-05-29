using System;
using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Repository.ReadOnly
{
    public interface IProdutoReadOnlyRepository
    {
        Produto GetById(Guid id);
        IEnumerable<Produto> GetAll();
        IEnumerable<Produto>GetByName(string nome);
        IEnumerable<Produto>BuscarPorCategoria(string categoria);
    }
}