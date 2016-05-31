﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.Application.ViewModel
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            ProdutoId = Guid.NewGuid();
            Categorias = new List<CategoriaViewModel>();
        }

        [Key]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }

        [ScaffoldColumn(false)]
        public virtual IEnumerable<CategoriaViewModel> Categorias { get; set; }
    }
}