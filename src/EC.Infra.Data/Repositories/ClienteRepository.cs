using System.Data.Entity;
using System.Linq;
using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, DataContext> , IClienteRepository
    {
        public Cliente ObterPorCPF(string cpf)
        {
            return Find(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Find(c => c.Email == email).FirstOrDefault();
        }

        public override void Remove(Cliente cliente)
        {
            var entry = Context.Entry(cliente);
            DbSet.Attach(cliente);
            entry.State = EntityState.Deleted;
        }
    }
}