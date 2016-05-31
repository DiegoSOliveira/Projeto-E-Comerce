using System;
using System.Collections.Generic;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICategoriaReadOnlyRepository
    {
        Categoria GetById(Guid Id);
        Categoria GetByName(string nome);
        IEnumerable<Categoria> GetAll();
    }
}