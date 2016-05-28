using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Specification;

namespace EC.Domain.Specification.Clientes
{
    public class ClientePossuiUmUnicoEmail : ISpecification<Cliente>
    {
        private readonly IClienteReadOnlyRepository _clienteReadOnlyRepository;

        public ClientePossuiUmUnicoEmail(IClienteReadOnlyRepository clienteReadOnlyRepository)
        {
            _clienteReadOnlyRepository = clienteReadOnlyRepository;
        }
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteReadOnlyRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}