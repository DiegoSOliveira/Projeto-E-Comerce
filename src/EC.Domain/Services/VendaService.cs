using System;
using System.Collections.Generic;
using EC.Domain.Entities.Vendas;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        private readonly IVendaReadOnlyRepository _vendaReadOnlyRepository;
        private readonly IVendaRepository _vendaRepository;

        public VendaService(
            IVendaReadOnlyRepository vendaReadOnlyRepository,
            IVendaRepository vendaRepository)
            : base(vendaRepository)
        {
            _vendaReadOnlyRepository = vendaReadOnlyRepository;
            _vendaRepository = vendaRepository;
        }

        public override IEnumerable<Venda> GetAll()
        {
            return _vendaReadOnlyRepository.GetAll();
        }

        public override Venda GetById(Guid id)
        {
            return _vendaReadOnlyRepository.GetById(id);
        }

        public IEnumerable<Venda> GetByCliente(Guid IdCliente)
        {
            return _vendaReadOnlyRepository.GetByCliente(IdCliente);
        }

        public IEnumerable<Venda> GetVendaForDates(DateTime DtInicio, DateTime DtFim)
        {
            return _vendaReadOnlyRepository.GetVendaForDates(DtInicio, DtFim);
        }
    }
}