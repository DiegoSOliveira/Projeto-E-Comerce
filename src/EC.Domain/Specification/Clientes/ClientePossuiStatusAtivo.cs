using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Specification;

namespace EC.Domain.Specification.Clientes
{
    public class ClientePossuiStatusAtivo : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Ativo;
        }
    }
}