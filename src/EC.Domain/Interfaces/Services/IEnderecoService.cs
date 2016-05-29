using System;
using System.Collections.Generic;
using EC.Domain.Entities.Geografia;

namespace EC.Domain.Interfaces.Services
{
    public interface IEnderecoService : IServiceBase<Endereco>
    {
        IEnumerable<Endereco>GetByCliente(Guid clienteId);
    }
}