using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ActoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            // uso de select con tipo anonimo
           var actores = await context.Actores.Select(
                a => new { a.Id, a.Nombre, a.Apellido, a.FechaNacimiento}).ToListAsync();
            return Ok(actores);

            /* uso de mapper
             return await context.Actores.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
            */
        }
    }
}
