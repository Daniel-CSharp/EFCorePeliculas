﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades
{
    public class PeliculaActor
    {
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }
        // propiedades de navegación (muchos a muchos manual)
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }

    }
}
