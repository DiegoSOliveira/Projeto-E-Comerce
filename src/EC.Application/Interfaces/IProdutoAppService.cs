using System;
using System.Collections.Generic;
using EC.Application.ViewModel;

namespace EC.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        void Add(ProdutoViewModel produtoViewModel);
        ProdutoViewModel GetById(Guid id);
        IEnumerable<ProdutoViewModel> GetAll();
        void Update(ProdutoViewModel produtoViewModel);
        void Remove(ProdutoViewModel produtoViewModel);
        IEnumerable<ProdutoViewModel> BuscarPorNome(string nome);
    }
}