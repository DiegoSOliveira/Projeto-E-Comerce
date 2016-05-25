using System.Data.Entity.ModelConfiguration;
using EC.Domain.Entities.Produtos;

namespace EC.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.Nome)
                .IsRequired();
        }
    }
}