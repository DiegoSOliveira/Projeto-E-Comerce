using System;
using System.Collections.Generic;

namespace EC.Domain.Entities.Produtos
{
    public class Categoria
    {
        public Categoria()
        {
            IdCategoria = Guid.NewGuid();
            Produtos = new List<Produto>();
        }

        public Guid IdCategoria { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}