using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        // propiedad de navegación (muchos a muchos automatica)
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
