﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterURL { get; set; }
        // propiedad de navegación (muchos a muchos automatica)
        public List<Genero> Generos { get; set; }
        // propiedad de navegación (muchos a muchos automatica)
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
        // propiedad de navegación (muchos a muchos manual)
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
