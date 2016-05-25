﻿using System;

namespace EC.Domain.Entities.Geografia
{
    public class Cidade
    {
        public Cidade()
        {
            CidadeId = Guid.NewGuid();
        }

        public Guid CidadeId { get; set; }
        public string Nome { get; set; }
        public Guid EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}