using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.Application.ViewModel
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid EnderecoId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Rua { get; set; }

        [Required]
        [MaxLength(6)]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(8)]
        public string CEP { get; set; }

        [Required]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public virtual ClienteViewModel Cliente { get; set; }

    }
}