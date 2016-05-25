using System.Linq;
using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Specification;

namespace EC.Domain.Specification.Clientes
{
    public class ClientePossuiEnderecoCadastrado : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.EnderecoList != null && cliente.EnderecoList.Any();
        }
    }
}