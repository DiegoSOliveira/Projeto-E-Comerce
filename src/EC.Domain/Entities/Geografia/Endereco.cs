using System;
using System.Collections.Generic;
using EC.Domain.Entities.Clientes;

namespace EC.Domain.Entities.Geografia
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public Guid EstadoId { get; set; }
        public Guid CidadeId { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}