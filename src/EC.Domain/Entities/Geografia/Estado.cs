using System;
using System.Collections.Generic;

namespace EC.Domain.Entities.Geografia
{
    public class Estado
    {
        public Estado()
        {
            EstadoId = Guid.NewGuid();
            Cidades = new List<Cidade>();
        }

        public Guid EstadoId { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }
}