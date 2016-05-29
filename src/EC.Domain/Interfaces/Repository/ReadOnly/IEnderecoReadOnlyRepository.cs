using System;
using System.Collections.Generic;
using EC.Domain.Entities.Geografia;

namespace EC.Domain.Interfaces.Repository.ReadOnly
{
    public interface IEnderecoReadOnlyRepository
    {
        IEnumerable<Endereco> GetByCliente(Guid clienteId);
        Endereco GetById(Guid id);
        IEnumerable<Endereco> GetAll();
    }
}