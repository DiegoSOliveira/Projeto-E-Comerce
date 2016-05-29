using System.Collections.Generic;
using EC.Domain.Entities.Produtos;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaReadOnlyRepository _categoriaReadOnly;

        public CategoriaService(ICategoriaRepository categoriaRepository, ICategoriaReadOnlyRepository categoriaReadOnly) : base(categoriaRepository)
        {
            _categoriaReadOnly = categoriaReadOnly;
            _categoriaRepository = categoriaRepository;
        }

        public Categoria GetByName(string nome)
        {
            return _categoriaReadOnly.GetByName(nome);
        }

        public override IEnumerable<Categoria> GetAll()
        {
            return _categoriaReadOnly.GetAll();
        }
    }
}