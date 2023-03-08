using AutoMapper;
using back_end.DTOs.Genero;
using back_end.DTOs.Paginacion;
using back_end.Entidades;
using back_end.Filtros;
using back_end.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<GenerosController> logger;
        private readonly IMapper mapper;

        public GenerosController(ILogger<GenerosController> logger,
            ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        //[ServiceFilter(typeof(MiFiltroDeAccion))]
        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Generos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            //var generos = await context.Generos.ToListAsync();

            return mapper.Map<List<GeneroDTO>>(generos);
            
        }
        //public ActionResult<List<Genero>> Get()
        //{
        //    logger.LogInformation("Vamos a mostrar los generos");
        //    return repositorio.ObtenerTodosLosGeneros();
        //}

        //[HttpGet("guid")]
        //public ActionResult<Guid> GetGUID()
        //{
        //    return repositorio.ObtenerGuid();
        //}

        [HttpGet("todos")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GeneroDTO>>> Todos()
        { 
            var generos = await context.Generos.ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroDTO>> Get(int Id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);

            if(genero == null)
            {
                return NotFound();
            }
            return mapper.Map<GeneroDTO>(genero);
        }
        //public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        //{
        //    logger.LogDebug($"Obteniendo un género por el id {Id}");
        //    var genero = await repositorio.ObtenerPorId(Id);

        //    if(genero == null)
        //    {
        //        throw new ApplicationException($"El género de ID {Id} no fue encontrado.");
        //    }

        //    return genero;
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
        //public ActionResult Post([FromBody] Genero genero)
        //{
        //   return NoContent();
        //}

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);

            if (genero == null)
            {
                return NotFound();
            }
            genero = mapper.Map(generoCreacionDTO, genero);

            await context.SaveChangesAsync();
            return NoContent();
        }
        //public ActionResult Put([FromBody] Genero genero)
        //{
        //    repositorio.CrearGenero(genero);
        //    return NoContent();
        //}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Generos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Genero() { Id = id });

            await context.SaveChangesAsync();
            return NoContent();
        }
        //public ActionResult Delete()
        //{
        //    return NoContent();
        //}
    }
}
