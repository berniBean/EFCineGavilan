using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFPeliculas.Entidades.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFPeliculas.Controllers
{
    [ApiController]
    [Route("api/Cines")]
    public class CinesController : Controller
    {
        private readonly ApliccationDbContext _context;
        private readonly IMapper _mapper;

        public CinesController(ApliccationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        [HttpGet]
        public async Task<IEnumerable<CineDTO>> Get()
        {
            return await _context.Cines.ProjectTo<CineDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("Cercanos")]
        public async Task<ActionResult> Get(double latitud, double longitud)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud));

            var cines = await _context.Cines
                .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                .Select(c => new
                {
                    Nombre = c.Nombre,
                    Distancia = Math.Round(c.Ubicacion.Distance(miUbicacion))
                }).ToListAsync();
        }
    }
}
