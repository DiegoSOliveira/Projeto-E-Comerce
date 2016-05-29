using System;
using System.Collections.Generic;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository.ReadOnly;

namespace EC.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto>GetByName(string nome);
        IEnumerable<Produto> BuscarPorCategoria(string categoria);
    }
}