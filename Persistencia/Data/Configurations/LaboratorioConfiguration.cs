using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> builder)
    {
        builder.ToTable("laboratorio");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Direccion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Telefono)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new Laboratorio { Id = 1, Nombre = "Genfar", Direccion = "cll 32 a", Telefono = "5454"},
            new Laboratorio { Id = 2, Nombre = "MK", Direccion = "# trs 787", Telefono = "767676"}
        );
    }
}
