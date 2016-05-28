using System.Linq;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Validation.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EC.Domain.Test.Validations
{
    [TestClass]
    public class ClienteAptoParaCadastroTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            Cliente = new Cliente()
            {
                CPF = "01109559275",
                Email = "diego@diego.br"
            };

            Cliente.EnderecoList.Add(new Endereco());

            var stubRepo = MockRepository.GenerateMock<IClienteRepository>();
            //stubRepo.Stub(s => s.ObterPorCPF(Cliente.CPF)).Return(null);
            //stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(null);

            var cliValidation = new ClienteEstaAptoParaCadastroNoSistema();
            Assert.IsTrue(cliValidation.Validar(Cliente).IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            Cliente = new Cliente()
            {
                CPF = "01109559275",
                Email = "diego@diego.br"
            };

            var clienteResult = Cliente;

            var stubRepo = MockRepository.GenerateMock<IClienteRepository>();
            //stubRepo.Stub(s => s.ObterPorCPF(Cliente.CPF)).Return(clienteResult);
            //stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(clienteResult);

            var cliValidation = new ClienteEstaAptoParaCadastroNoSistema();
            var result = cliValidation.Validar(Cliente);

            Assert.IsFalse(clienteResult.IsValid());
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF já cadastrado! Esqueceu sua Senha?"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Email já cadastrado! Esqueceu sua senha?"));
        }
    }
}