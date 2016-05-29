using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.Application.ViewModel
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            CategoriaId = Guid.NewGuid();
        }
        [Key]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Categoria")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome Categoria")]
        public string Nome { get; set; }

        public ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}