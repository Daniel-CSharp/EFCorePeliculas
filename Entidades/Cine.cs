using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        // propiedad de navegación (1 a 1)
        public CineOferta CineOferta { get; set; }
        // propiedad de navegación (1 a muchos)
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
    }
}
