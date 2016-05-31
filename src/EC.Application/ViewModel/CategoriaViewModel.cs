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
            Produtos = new List<ProdutoViewModel>();
        }
        [Key]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Categoria")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome Categoria")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}