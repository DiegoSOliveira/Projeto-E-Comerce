using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Domain.ValuesObjects;

namespace EC.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        //Cliente ObterPorCPF(string cpf);
        //Cliente ObterPorEmail(string email);
        ValidationResult AdicionarCliente(Cliente cliente);
        int ObterTotalRegistros(string pesquisa);
        IEnumerable<Cliente> ObterClientesGrid(int page, string pesquisa);
    }
}