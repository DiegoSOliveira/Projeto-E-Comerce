using System.Collections.Generic;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        //public IEnumerable<Produto> ObterCategoria(string nome)
        //{
        //    return _categoriaRepository.ObterCategoria(nome);
        //}
    }
}