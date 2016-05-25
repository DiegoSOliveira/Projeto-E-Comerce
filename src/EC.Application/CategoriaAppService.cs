using System;
using System.Collections.Generic;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.ViewModel;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class CategoriaAppService : AppServiceBase<DataContext>, ICategoriaService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService( ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterCategoria(string nome)
        {
            throw new NotImplementedException();
        }
    }
}