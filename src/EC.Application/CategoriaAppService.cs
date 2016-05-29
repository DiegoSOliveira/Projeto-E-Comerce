using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.Validation;
using EC.Application.ViewModel;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class CategoriaAppService : AppServiceBase<DataContext>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService( ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public void Add(CategoriaViewModel categoriaViewModel)
        {
            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
            BeginTransaction();
            _categoriaService.Add(categoria);
            Commit();
        }

        public CategoriaViewModel GetById(Guid id)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(_categoriaService.GetById(id));
        }

        public IEnumerable<CategoriaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaService.GetAll());
        }

        public void Update(CategoriaViewModel categoriaViewModel)
        {
            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
            BeginTransaction();
            _categoriaService.Update(categoria);
            Commit();
        }

        public void Remove(CategoriaViewModel categoriaViewModel)
        {
            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
            BeginTransaction();
            _categoriaService.Remove(categoria);
            Commit();
        }

        public Categoria GetByName(string nome)
        {
            return _categoriaService.GetByName(nome);
        }

        public void Dispose()
        {
            _categoriaService.Dispose();
        }
    }
}