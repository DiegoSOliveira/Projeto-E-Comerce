using EC.Domain.Entities.Clientes;
using EC.Domain.Specification.Clientes;
using EC.Domain.Validation.Base;

namespace EC.Domain.Validation.Clientes
{
    public class ClienteEstaAptoParaCadastroNoSistema : FiscalBase<Cliente>
    {
        public ClienteEstaAptoParaCadastroNoSistema()
        {
            var clienteEndereco = new ClientePossuiEnderecoCadastrado();
            var clienteAtivo = new ClientePossuiStatusAtivo();
            var clienteCPFValido = new ClientePossuiCpfValido();

            base.AdicionarRegra("ClienteEspecial", new Regra<Cliente>(clienteEndereco, "Cliente não possui endereço castrado"));
            base.AdicionarRegra("ClienteAtivo", new Regra<Cliente>(clienteAtivo, "Cliente não está ativo no sistema"));
            base.AdicionarRegra("ClienteCPFValido", new Regra<Cliente>(clienteCPFValido, "Cliente informou um CPF Inválido"));
        }
    }
}