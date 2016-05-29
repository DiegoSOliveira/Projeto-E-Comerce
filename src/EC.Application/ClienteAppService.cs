using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.Validation;
using EC.Application.ViewModel;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class ClienteAppService : AppServiceBase<DataContext>, IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IEnderecoService _enderecoService;

        public ClienteAppService(IClienteService clienteService, IEnderecoService enderecoService)
        {
            _clienteService = clienteService;
            _enderecoService = enderecoService;
        }

        public ValidationAppResult Add(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);

            BeginTransaction();

            cliente.EnderecoList.Add(endereco);

            var result = _clienteService.AdicionarCliente(cliente);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            _clienteService.Add(cliente);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ClienteViewModel GetById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(id));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.GetAll());
        }

        public void Update(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            BeginTransaction();
            _clienteService.Update(cliente);
            Commit();
        }

        public void Remove(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
            var endereco = _enderecoService.GetByCliente(cliente.ClienteId);
            BeginTransaction();
            if (endereco.Count() != 0)
            {
                foreach (var end in endereco)
                {
                    _enderecoService.Remove(end);
                }
            }
            _clienteService.Remove(cliente);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
        }


        public IEnumerable<ClienteViewModel> ObterClientesGrid(int page, string pesquisa)
        {
            return
                Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterClientesGrid(page,pesquisa));
        }


        public int ObterTotalRegistros(string pesquisa)
        {
            return _clienteService.ObterTotalRegistros(pesquisa);
        }
    }
}