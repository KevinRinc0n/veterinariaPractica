using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
{
    public void Configure(EntityTypeBuilder<Propietario> builder)
    {
        builder.ToTable("propietario");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Telefono)
        .IsRequired()
        .HasMaxLength(50);
        
        builder.HasData(
            new Propietario { Id = 1, Nombre = "pri", Email = "pri@gmail.com", Telefono = "3213"},
            new Propietario { Id = 2, Nombre = "raul", Email = "raul@gmail.com", Telefono = "54545"},
            new Propietario { Id = 3, Nombre = "stiven", Email = "stiven@gmail.com", Telefono = "87878"}
        );
    }
}