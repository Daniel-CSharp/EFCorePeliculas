﻿using AutoMapper;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Servicios
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();

            CreateMap<Cine, CineDTO>()
             .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
             .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));

            CreateMap<Genero, GeneroDTO>();

            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.Cines, ent => ent.MapFrom(prop => prop.SalasDeCine.Select(s => s.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(prop => prop.PeliculasActores.Select(pa => pa.Actor)));
        }
    }
}
