using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
