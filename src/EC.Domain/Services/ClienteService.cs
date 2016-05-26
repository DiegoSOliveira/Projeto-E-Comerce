using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;
using EC.Domain.ValuesObjects;

namespace EC.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        //public Cliente ObterPorCPF(string cpf)
        //{
        //    return _clienteRepository.ObterPorCPF(cpf);
        //}

        //public Cliente ObterPorEmail(string email)
        //{
        //    return _clienteRepository.ObterPorEmail(email);
        //}

        public ValidationResult AdicionarCliente(Cliente cliente)
        {
            var resultadoValidacao = new ValidationResult();

            if (!cliente.IsValid())
            {
                resultadoValidacao.AdicionarErro(cliente.ResultadoValidacao);
                return resultadoValidacao;
            }

            base.Add(cliente);

            return resultadoValidacao;
        }

        //public int ObterTotalRegistros(string pesquisa)
        //{
        //    return _clienteRepository.ObterTotalRegistros(pesquisa);
        //}

        //public IEnumerable<Cliente> ObterClientesGrid(int page, string pesquisa)
        //{
        //    return _clienteRepository.ObterClientesGrid(page, pesquisa);
        //}
    }
} 