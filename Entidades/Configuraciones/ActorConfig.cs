using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Nombre)
              .HasMaxLength(150)
              .IsRequired();

            builder.Property(prop => prop.Apellido)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(prop => prop.FechaNacimiento)
                .HasColumnType("date");

        }
    }
}
