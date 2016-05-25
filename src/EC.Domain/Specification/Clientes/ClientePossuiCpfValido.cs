using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Specification;
using EC.Domain.Validation.Documentos;

namespace EC.Domain.Specification.Clientes
{
    public class ClientePossuiCpfValido : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}