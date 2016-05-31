using System;
using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        Categoria GetById(Guid Id);
        Categoria GetByName(string nome);
        IEnumerable<Categoria> GetAll();
    }
}