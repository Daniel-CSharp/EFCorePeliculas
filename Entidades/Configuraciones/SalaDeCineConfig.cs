using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 5, scale: 2);

            builder.Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);
        }
    }
}
