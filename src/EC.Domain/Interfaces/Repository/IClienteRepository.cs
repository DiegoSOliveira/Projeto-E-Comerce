using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;

namespace EC.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        //Cliente ObterPorCPF(string cpf);
        //Cliente ObterPorEmail(string email);
        //int ObterTotalRegistros(string pesquisa);
        //IEnumerable<Cliente> ObterClientesGrid(int page, string pesquisa);
    }
}