using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Produtos;

namespace EC.Domain.Entities.Vendas
{
    public class Venda
    {
        public Venda()
        {
            VendaId = Guid.NewGuid();
            ProdutosList = new List<Produto>();
        }

        public Guid VendaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<Produto> ProdutosList { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}