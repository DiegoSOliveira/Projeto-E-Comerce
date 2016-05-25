using System.Data.Entity.ModelConfiguration;
using EC.Domain.Entities.Vendas;

namespace EC.Infra.Data.EntityConfig
{
    public class VendaConfiguration : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguration()
        {
            HasKey(v => v.VendaId);

            Property(v => v.Valor)
                .IsRequired();

            Property(v => v.DataCadastro)
                .IsRequired();

            HasMany(v => v.ProdutosList)
                .WithMany(p => p.VendaList)
                .Map(me =>
                {
                    me.MapLeftKey("VendaId");
                    me.MapRightKey("ProdutoId");
                    me.ToTable("VendaProdutos");
                });
        }
    }
}