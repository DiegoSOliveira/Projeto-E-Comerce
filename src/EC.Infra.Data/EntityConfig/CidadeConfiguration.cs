using System.Data.Entity.ModelConfiguration;
using EC.Domain.Entities.Geografia;

namespace EC.Infra.Data.EntityConfig
{
    public class CidadeConfiguration : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            HasKey(c => c.CidadeId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(c => c.Estado)
                .WithMany()
                .HasForeignKey(c => c.EstadoId);
        }
    }
}