using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        // propiedad de navegación (muchos a muchos manual)
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
