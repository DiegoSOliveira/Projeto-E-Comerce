using System.Data.Entity.ModelConfiguration;
using EC.Domain.Entities.Produtos;

namespace EC.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Valor)
                .IsRequired();

            HasMany(p => p.Categorias)
                .WithMany(c => c.Produtos)
                .Map(me =>
                {
                    me.MapLeftKey("ProdutoId");
                    me.MapRightKey("CategoriaId");
                    me.ToTable("ProdutoCategoria");
                });
        }
    }
}