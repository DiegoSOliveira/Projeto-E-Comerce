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
    public class ProdutoAppService : AppServiceBase<DataContext>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<ProdutoViewModel> BuscarPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoService.GetAll());
        }

        public void Add(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _produtoService.Add(produto);
            Commit();
        }

        public ProdutoViewModel GetById(Guid id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_produtoService.GetById(id));
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoService.GetAll());
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _produtoService.Update(produto);
            Commit();
        }

        public void Remove(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _produtoService.Remove(produto);
            Commit();
        }

        public void Dispose()
        {
            _produtoService.Dispose();
        }
    }
}