using System;
using System.Collections.Generic;
using EC.Domain.Entities.Geografia;
using EC.Domain.Entities.Vendas;
using EC.Domain.Validation.Clientes;
using EC.Domain.ValuesObjects;

namespace EC.Domain.Entities.Clientes
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Venda> ProdutosComprados { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
        public ValidationResult ResultadoValidacao { get; private set; }

        public bool IsValid()
        {
            var fiscal = new ClienteEstaAptoParaCadastroNoSistema();

            ResultadoValidacao = fiscal.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}