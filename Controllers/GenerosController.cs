using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.OrderBy(g => g.Nombre).ToListAsync();
        }

        /* StartUp.cs =>  opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking) (comportamiento x defecto);
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.AsNoTracking().ToListAsync();
        }
        */

        [HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("Z"));

            if(genero is null)
            {
                return new NotFoundResult();
            }
            return genero;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return new NotFoundResult();
            }
            return genero;
        }

        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> Filtrar()
        {
            return await context.Generos
                .Where(g => g.Nombre.StartsWith("C") || g.Nombre.StartsWith("A"))
                .OrderBy(g => g.Nombre)
                .ToListAsync();
        }

        [HttpGet("filtrarPorNombre")]
        public async Task<IEnumerable<Genero>> FiltrarPorNombre(string nombre)
        {
            return await context.Generos.Where(
                g => g.Nombre.Contains(nombre)
                ).ToListAsync();
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int pagina = 1)
        {
            var cantidadRegistrosPorpagina = 3;
            var generos = await context.Generos
                .Skip((pagina - 1) * cantidadRegistrosPorpagina)
                .Take(cantidadRegistrosPorpagina)
                .ToListAsync();
            return generos;
        }
    }
}
