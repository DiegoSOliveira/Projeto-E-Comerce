using System;
using System.Collections.Generic;

namespace EC.Domain.Entities.Clientes
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            //EnderecoList = new List<Endereco>();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        //public virtual ICollection<Venda> ProdutosComprados { get; set; }
        //public virtual ICollection<Endereco> EnderecoList { get; set; }
    }
}