using System.Data.Entity.ModelConfiguration;
using EC.Domain.Entities.Geografia;

namespace EC.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Rua)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired();

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8);

            Property(e => e.Complemento)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(e => e.Cliente)
                .WithMany(c => c.EnderecoList)
                .HasForeignKey(e => e.ClienteId);
        }
    }
}