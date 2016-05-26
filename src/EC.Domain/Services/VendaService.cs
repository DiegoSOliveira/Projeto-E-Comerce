using System.Collections.Generic;
using EC.Domain.Entities.Vendas;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        //private readonly IVendaReadOnlyRepository _vendaReadOnlyRepository;
        private readonly IVendaRepository _vendaRepository;

        public VendaService(
            //IVendaReadOnlyRepository vendaReadOnlyRepository,
            IVendaRepository vendaRepository)
            : base(vendaRepository)
        {
            //_vendaReadOnlyRepository = vendaReadOnlyRepository;
            _vendaRepository = vendaRepository;
        }

        public IEnumerable<Venda> GetAll()
        {
            return _vendaRepository.GetAll();
        }
    }
}