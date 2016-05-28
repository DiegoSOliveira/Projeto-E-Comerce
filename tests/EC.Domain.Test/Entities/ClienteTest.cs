using System;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Geografia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EC.Domain.Test.Entities
{
    [TestClass]
    public class ClienteTest
    {
        public Cliente Cliente { get; set; }
        public Endereco Endereco { get; set; }

        [TestMethod]
        public void ClienteConsistente_True()
        {
            Endereco = new Endereco()
            {
                Rua = "Rua X",
                Bairro = "Bairro H",
                CEP = "12345678",
                Cidade = "Porto Velho"              
            };

            Cliente = new Cliente()
            {
                CPF = "01109559275",
                Email = "cliente@cliente.com.br",
                Ativo = true,
            };
            Cliente.EnderecoList.Add(Endereco);

            Assert.IsTrue(Cliente.IsValid());
        }

        [TestMethod]
        public void ClienteConsistente_false()
        {
            Endereco = new Endereco()
            {
                Rua = "Rua X",
                Bairro = "Bairro H",
                CEP = "12345678",
                Cidade = "Porto Velho"
            };

            Cliente = new Cliente()
            {
                CPF = "01109559275",
                Email = "cliente@cliente.com.br",
                Ativo = false,
            };

            Cliente.EnderecoList.Add(Endereco);

            Assert.IsFalse(Cliente.IsValid());
        }

    }
}