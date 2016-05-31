using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.Validation;
using EC.Application.ViewModel;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class CategoriaAppService : AppServiceBase<DataContext>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ICategoriaReadOnlyRepository _categoriaReadOnly;

        public CategoriaAppService( ICategoriaService categoriaService, ICategoriaReadOnlyRepository categoriaReadOnly)
        {
            _categoriaReadOnly = categoriaReadOnly;
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
            return Mapper.Map<Categoria, CategoriaViewModel>(_categoriaReadOnly.GetById(id));
        }

        public IEnumerable<CategoriaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaReadOnly.GetAll());
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

        public CategoriaViewModel GetByName(string nome)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(_categoriaReadOnly.GetByName(nome));
        }

        public void Dispose()
        {
            _categoriaService.Dispose();
        }
    }
}