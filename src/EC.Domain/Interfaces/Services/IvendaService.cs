using System;
using System.Collections.Generic;
using EC.Domain.Entities.Vendas;

namespace EC.Domain.Interfaces.Services
{
    public interface IVendaService : IServiceBase<Venda>
    {
        IEnumerable<Venda> GetByCliente(Guid IdCliente);
        IEnumerable<Venda> GetVendaForDates(DateTime DtInicio, DateTime DtFim);
    }
}