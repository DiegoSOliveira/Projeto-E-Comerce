using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;
using EC.Domain.Validation.Clientes;
using EC.Domain.ValuesObjects;

namespace EC.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteReadOnlyRepository _clienteReadOnlyRepository;

        public ClienteService(IClienteRepository clienteRepository, IClienteReadOnlyRepository clienteReadOnlyRepository) : base(clienteRepository)
        {
            _clienteReadOnlyRepository = clienteReadOnlyRepository;
            _clienteRepository = clienteRepository;
        }

        public Cliente ObterPorCPF(string cpf)
        {
            return _clienteReadOnlyRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteReadOnlyRepository.ObterPorEmail(email);
        }

        public ValidationResult AdicionarCliente(Cliente cliente)
        {
            var resultadoValidacao = new ValidationResult();

            if (!cliente.IsValid())
            {
                resultadoValidacao.AdicionarErro(cliente.ResultadoValidacao);
                return resultadoValidacao;
            }

            var clienteApto = new ClienteEstaAptoParaCadastroNoSistema(_clienteReadOnlyRepository);
            if (!cliente.ClienteApto(clienteApto))
            {
                resultadoValidacao.AdicionarErro(cliente.ResultadoValidacao);
                return resultadoValidacao;
            }

            base.Add(cliente);

            return resultadoValidacao;
        }
        public override Cliente GetById(Guid id)
        {
            return _clienteReadOnlyRepository.GetById(id);
        }

        public override IEnumerable<Cliente> GetAll()
        {
            return _clienteReadOnlyRepository.GetAll();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _clienteReadOnlyRepository.ObterTotalRegistros(pesquisa);
        }

        public IEnumerable<Cliente> ObterClientesGrid(int page, string pesquisa)
        {
            return _clienteReadOnlyRepository.ObterClientesGrid(page, pesquisa);
        }
    }
} 