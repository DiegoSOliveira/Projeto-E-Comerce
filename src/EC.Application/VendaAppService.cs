using System;
using System.Collections.Generic;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.ViewModel;
using EC.Domain.Entities.Vendas;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class VendaAppService : AppServiceBase<DataContext>, IVendaAppService
    {
        private readonly IVendaService _vendaService;
        private readonly IVendaReadOnlyRepository _vendaReadOnly;

        public VendaAppService(IVendaService vendaService, IVendaReadOnlyRepository vendaReadOnly)
        {
            _vendaReadOnly = vendaReadOnly;
            _vendaService = vendaService;
        }

        public void Add(VendaViewModel vendaViewModel)
        {
            var venda = Mapper.Map<VendaViewModel, Venda>(vendaViewModel);
            BeginTransaction();
            _vendaService.Add(venda);
            Commit();
        }

        public VendaViewModel GetById(Guid id)
        {
            return Mapper.Map<Venda, VendaViewModel>(_vendaReadOnly.GetById(id));
        }

        public IEnumerable<VendaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(_vendaReadOnly.GetAll());
        }

        public void Update(VendaViewModel vendaViewModel)
        {
            var venda = Mapper.Map<VendaViewModel, Venda>(vendaViewModel);
            BeginTransaction();
            _vendaService.Update(venda);
            Commit();
        }

        public void Remove(VendaViewModel vendaViewModel)
        {
            var venda = Mapper.Map<VendaViewModel, Venda>(vendaViewModel);
            BeginTransaction();
            _vendaService.Remove(venda);
            Commit();
        }

        public IEnumerable<VendaViewModel> GetByCliente(Guid clienteId)
        {
            return Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(_vendaReadOnly.GetByCliente(clienteId));
        }

        public IEnumerable<VendaViewModel> GetVendaForDates(DateTime DtInicio, DateTime DtFim)
        {
            return Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(_vendaReadOnly.GetVendaForDates(DtInicio,DtFim));
        }

        public void Dispose()
        {
            _vendaService.Dispose();
        }
    }
}
