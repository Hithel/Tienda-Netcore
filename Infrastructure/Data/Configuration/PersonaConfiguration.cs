using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Configuration;
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");

            builder.Property(P => P.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasMaxLength(3);

            builder.Property(P => P.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaNacimiento)
            .IsRequired();

            builder.Property(P => P.EmailPersona)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(P => P.TipoPersona)
            .WithMany(P => P.Personas)
            .HasForeignKey(P => P.IdTipoPersona);

            builder.HasOne(P => P.Region)
            .WithMany(P => P.Personas)
            .HasForeignKey(P => P.IdRegionFK);

        }
    }
