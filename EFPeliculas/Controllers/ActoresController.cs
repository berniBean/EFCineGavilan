using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFPeliculas.Entidades.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFPeliculas.Controllers
{
    [ApiController]
    [Route("api/Actores")]
    public class ActoresController : Controller
    {
        private readonly ApliccationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApliccationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            return await _context.Actores
                .ProjectTo<ActorDTO>(_mapper.ConfigurationProvider).ToListAsync();
                
        }
    }
}
