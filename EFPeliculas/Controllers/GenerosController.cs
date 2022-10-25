using AutoMapper;
using EFPeliculas.Entidades;
using EFPeliculas.Entidades.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EFPeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : Controller
    {
        private readonly ApliccationDbContext _context;
        private readonly IMapper _mapper;

        public GenerosController(ApliccationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GeneroDTO>> Get()
        {
            //solo para consulta sin actualizar a la DB
            //AsNoTracking Query de solo lectura
            var res = await _context.Generos.OrderBy(g => g.Nombre).ToListAsync();
            var mapper = _mapper.Map<List<Genero>,List<GeneroDTO>>(res);
            return mapper;
        }
        [HttpGet("primero")]
        public async Task<ActionResult<GeneroDTO>> Pimero()
        {
            var res = await _context.Generos.FirstOrDefaultAsync(
                g => g.Nombre.StartsWith("z"));

            if (res is null)
                return NotFound();
            var mapper = _mapper.Map<Genero,GeneroDTO>(res);
            return mapper;

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroDTO>> PorId(int id)
        {
            var res = await _context.Generos.FirstOrDefaultAsync(
                g => g.Identificador.Equals(id));

            if (res is null)
                return NotFound();
            var mapper = _mapper.Map<Genero, GeneroDTO>(res);
            return mapper;
        }

        [HttpGet("Filtrar")]
        public async Task<ActionResult<List<GeneroDTO>>> Filtrado()
        {
            var res = await _context.Generos.Where(
                g => g.Nombre.StartsWith("c") ||
                g.Nombre.StartsWith("a")).ToListAsync();

            if (res is null)
                return NotFound();
            var mapper = _mapper.Map<List<Genero>, List<GeneroDTO>>(res);
            return mapper;
        }


        [HttpGet("FiltrarNombre")]
        public async Task<ActionResult<List<GeneroDTO>>> FiltradoNombre(string nombre)
        {
            var res = await _context.Generos
                .Where(g => g.Nombre.Contains(nombre))
                .OrderBy(g => g.Nombre)
                .ToListAsync();

            if (res.Count == 0)
                return NotFound();
            var mapper = _mapper.Map<List<Genero>, List<GeneroDTO>>(res);
            return mapper;
        }

        [HttpGet("Paginar")]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> GetPaginacion(int pagina = 1)
        {
            var cantidadRegistrosPagina = 2;

            var res = await _context.Generos
                        .Skip((pagina - 1) * cantidadRegistrosPagina)
                        .Take(cantidadRegistrosPagina).ToListAsync();

            if (res.Count == 0)
                return NotFound();
            var mapper = _mapper.Map<List<Genero>, List<GeneroDTO>>(res);
            return mapper;
        }

    }
}
