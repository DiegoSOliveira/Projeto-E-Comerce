using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Specification.Clientes;
using EC.Domain.Validation.Base;

namespace EC.Domain.Validation.Clientes
{
    public class ClienteEstaAptoParaCadastroNoSistema : FiscalBase<Cliente>
    {
        public ClienteEstaAptoParaCadastroNoSistema(IClienteReadOnlyRepository clienteReadOnlyRepository)
        {
            var clienteEmailUnico = new ClientePossuiUmUnicoEmail(clienteReadOnlyRepository);
            var clienteCpfUnico = new ClientePossuiUmUnicoCpf(clienteReadOnlyRepository);

            base.AdicionarRegra("ClienteCpfUnico",new Regra<Cliente>(clienteCpfUnico,"CPF Já cadastrado! Esqueceu sua senha?"));
            base.AdicionarRegra("ClienteEmailUnico",new Regra<Cliente>(clienteEmailUnico,"Email já cadastrado! Esqueceu sua senha?"));
        }
    }
}