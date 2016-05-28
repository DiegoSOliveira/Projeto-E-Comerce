using EC.Domain.Entities.Clientes;
using EC.Domain.Specification.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EC.Domain.Test.Especifications
{
    [TestClass]
    public class CpfSpecification
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void CPF_Valido_True()
        {
            Cliente = new Cliente()
            {
                CPF = "01109559275"
            };

            var cpf = new ClientePossuiCpfValido();
            Assert.IsTrue(cpf.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void CPF_Valido_False()
        {
            Cliente = new Cliente()
            {
                CPF = "01195592755"
            };

            var cpf = new ClientePossuiCpfValido();
            Assert.IsFalse(cpf.IsSatisfiedBy(Cliente));
        }
    }
}