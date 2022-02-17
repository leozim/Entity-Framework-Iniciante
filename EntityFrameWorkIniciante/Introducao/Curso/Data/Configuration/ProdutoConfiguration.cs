using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Data.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CodigoBarras).HasColumnType("CHAR(14)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(255)");
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Tipo).HasConversion<string>();
        }
    }
}