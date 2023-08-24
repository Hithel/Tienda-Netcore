using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.Property(P => P.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasMaxLength(3);

            builder.Property(P => P.CodInterno)
            .HasColumnType("text");

            builder.Property(P => P.NombreProducto)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(P => P.StockMin)
            .HasColumnType("int");

            builder.Property(P => P.StockMax)
            .HasColumnType("int");

            builder.Property(P => P.Stock)
            .HasColumnType("int");

            builder.Property(P => P.ValorVenta)
            .HasColumnType("double");
        }
    }
}