using System.Linq;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
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

            var stubRepo = MockRepository.GenerateMock<IClienteReadOnlyRepository>();
            stubRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(null);
            stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(null);

            var cliValidation = new ClienteEstaAptoParaCadastroNoSistema(stubRepo);
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

            Cliente cli = new Cliente()
            {
                CPF = "16204166204",
                Email = "diego.edu@diego.br"
            };

            var clienteResult = Cliente;

            var stubRepo = MockRepository.GenerateMock<IClienteReadOnlyRepository>();
            stubRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(cli);
            stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(cli);

            var cliValidation = new ClienteEstaAptoParaCadastroNoSistema(stubRepo);
            var result = cliValidation.Validar(Cliente);

            Assert.IsFalse(clienteResult.IsValid());
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF Já cadastrado! Esqueceu sua senha?"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Email já cadastrado! Esqueceu sua senha?"));
        }
    }
}