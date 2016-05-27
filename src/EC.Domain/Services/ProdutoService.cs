using System;
using System.Collections.Generic;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoReadOnlyRepository _produtoReadOnlyRepository;
        public ProdutoService(IProdutoRepository produtoRepository, IProdutoReadOnlyRepository produtoReadOnlyRepository) : base(produtoRepository)
        {
            _produtoReadOnlyRepository = produtoReadOnlyRepository;
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> GetByName(string nome)
        {
            return _produtoRepository.GetByName(nome);
        }

        public override IEnumerable<Produto> GetAll()
        {
            return _produtoReadOnlyRepository.GetAll();
        }

        public override Produto GetById(Guid id)
        {
            return _produtoReadOnlyRepository.GetById(id);
        }
    }
}