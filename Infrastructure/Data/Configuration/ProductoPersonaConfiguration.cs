using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Configuration;
    public class ProductoPersonaConfiguration : IEntityTypeConfiguration<ProductoPersona>
    {
        public void Configure(EntityTypeBuilder<ProductoPersona> builder)
        {
            builder.ToTable("ProductoPersona");

            builder.Property(PP => PP.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasMaxLength(3);

            builder.HasOne(PP => PP.Persona)
            .WithMany(PP => PP.ProductoPersonas)
            .HasForeignKey(PP => PP.IdPersonaFk);

            builder.HasOne(PP => PP.Producto)
            .WithMany(PP => PP.ProductoPersonas)
            .HasForeignKey(PP => PP.IdProductoFk);
        }
    }
