﻿using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository;
using EC.Infra.Data.Context;

namespace EC.Infra.Data.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade, DataContext>, ICidadeRepository
    {
        
    }
}