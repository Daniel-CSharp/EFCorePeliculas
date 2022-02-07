using AutoMapper;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using EFCorePeliculas.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Generos.OrderByDescending(g => g.Nombre))
                .Include(p => p.SalasDeCine)
                    .ThenInclude(s => s.Cine)
                .Include(p => p.PeliculasActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980))
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null)
            {
                return NotFound();
            }

            // mapeo sin uso de ProjectTo
            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            // para no obtener los cines repetidos
            peliculaDTO.Cines = peliculaDTO.Cines.Distinct(new CineIdComparer()).ToList();
            return peliculaDTO;
        }

        [HttpGet("cargadoselectivo/{id:int}")]
        public async Task<ActionResult>GetSelectivo(int id)
        {
            var pelicula = await context.Peliculas.Select(p => new
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre).ToList(),
                CantidadActores = p.PeliculasActores.Count(),
                CantidadCines = p.SalasDeCine.Select(s => s.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(p => p.Id == id);

            if(pelicula is null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpGet("cargadoexplicito/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetExplicito(int id)
        {
            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(p => p.Id == id);

            //await context.Entry(pelicula).Collection(p => p.Generos).LoadAsync();

            //no se cargan los generos, solo la cantidad
            await context.Entry(pelicula).Collection(p => p.Generos).Query().CountAsync();

            if (pelicula is null)
            {
                return NotFound();
            }

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);
            return peliculaDTO;
        }

        [HttpGet("agrupadasPorEstreno")]
        public async Task<ActionResult> GetAgrupadasPorCartelera()
        {
            var peliculasAgrupadas = await context.Peliculas.GroupBy(p => p.EnCartelera)
                .Select(g => new
                {
                    EnCartelera = g.Key,
                    Conteo = g.Count(),
                    Peliculas = g.ToList()
                }).ToListAsync();
            return Ok(peliculasAgrupadas);
        }
    }
        
}
