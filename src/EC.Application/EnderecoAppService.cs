using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.ViewModel;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class EnderecoAppService : AppServiceBase<DataContext>, IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public void Add(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            BeginTransaction();
            _enderecoService.Add(endereco);
            Commit();
        }

        public EnderecoViewModel GetById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_enderecoService.GetById(id));
        }

        public IEnumerable<EnderecoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoService.GetAll());
        }

        public void Update(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            BeginTransaction();
            _enderecoService.Update(endereco);
            Commit();
        }

        public void Remove(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            BeginTransaction();
            _enderecoService.Remove(endereco);
            Commit();
        }

        public IEnumerable<EnderecoViewModel> GetByCliente(Guid clienteId)
        {
            return Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoService.GetByCliente(clienteId));
        }

        public void Dispose()
        {
            _enderecoService.Dispose();
        }
    }
}