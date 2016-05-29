﻿using System;
using System.Collections.Generic;
using EC.Domain.Entities.Vendas;

namespace EC.Domain.Interfaces.Repository.ReadOnly
{
    public interface IVendaReadOnlyRepository
    {
        Venda GetById(Guid id);
        IEnumerable<Venda> GetAll();
        IEnumerable<Venda> GetByCliente(Guid clienteId);
        IEnumerable<Venda> GetVendaForDates(DateTime  DtInicio, DateTime DtFim);
    }
}