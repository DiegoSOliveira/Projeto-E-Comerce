using System;
using System.Collections.Generic;
using EC.Application.Validation;
using EC.Application.ViewModel;
using EC.Domain.Entities.Produtos;

namespace EC.Application.Interfaces
{
    public interface ICategoriaAppService : IDisposable
    {
        void Add(CategoriaViewModel categoriaViewModel);
        CategoriaViewModel GetById(Guid id);
        IEnumerable<CategoriaViewModel> GetAll();
        void Update(CategoriaViewModel categoriaViewModel);
        void Remove(CategoriaViewModel categoriaViewModel);
    }
}