using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente> , IClienteRepository
    {

    }
}