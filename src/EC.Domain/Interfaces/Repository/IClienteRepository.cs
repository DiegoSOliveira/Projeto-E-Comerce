using System;
using EC.Domain.Entities.Clientes;

namespace EC.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente ObterPorCPF(string cpf);
        Cliente ObterPorEmail(string email);
    }
}