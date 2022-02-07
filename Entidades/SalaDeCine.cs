using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades
{
    public class SalaDeCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        // propiedad de navegación (1 a muchos)
        public Cine Cine { get; set; }
        // propiedad de navegación (muchos a muchos automatica)
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
