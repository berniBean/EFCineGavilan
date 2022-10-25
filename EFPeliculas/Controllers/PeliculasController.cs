using AutoMapper;
using EFPeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFPeliculas.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : Controller
    {
        private readonly ApliccationDbContext _context;
        private readonly IMapper _mapper;

        public PeliculasController(ApliccationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> GetId(int id)
        {
            var pelicula = await _context.Peliculas
                .Include(pelicula => pelicula.Generos)
                .Include(pelicula => pelicula.SalasDeCine)
                    .ThenInclude(salaCine => salaCine.Cine)
                .Include(pelicula => pelicula.PeliculaActores)
                    .ThenInclude(peliculaActor => peliculaActor.Actor)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return pelicula;
        }
    }
}
