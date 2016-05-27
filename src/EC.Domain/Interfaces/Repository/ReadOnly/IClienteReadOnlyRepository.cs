﻿using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;

namespace EC.Domain.Interfaces.Repository.ReadOnly
{
    public interface IClienteReadOnlyRepository
    {
        Cliente GetById(Guid id);
        IEnumerable<Cliente> GetAll();
        int ObterTotalRegistros(string pesquisa);
        IEnumerable<Cliente> ObterClientesGrid(int page, string pesquisa);
    }
}