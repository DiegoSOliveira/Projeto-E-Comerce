using System;
using System.Collections.Generic;

namespace EC.Domain.Entities.Produtos
{
    public class Produto
    {
        public Produto()
        {
            ProdutoId = Guid.NewGuid();
            Categorias = new List<Categoria>();
        }

        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
        //public Guid FornecedorId { get; set; }
        //public virtual ICollection<Venda> VendaList { get; set; }
    }
}