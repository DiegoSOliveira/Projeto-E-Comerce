using System.Data.Entity.ModelConfiguration;
using EC.Domain.Entities.Geografia;

namespace EC.Infra.Data.EntityConfig
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            HasKey(e => e.EstadoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.UF)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}