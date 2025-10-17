using GestionHuacales.Api9.DTO;
using GestionHuacales.Api9.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionHuacales.Api9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposHuacalesController(EntradasHuacalesServices entradaHuacalesServices) : ControllerBase
    {
        // GET: api/<TiposHuacalesController>
        [HttpGet]
        public async Task<TiposHuacalesDTO[]> Get()
        {
            return await entradaHuacalesServices.ListarTipos(t => true);
        }

        // GET api/<TiposHuacalesController>/5
        [HttpGet("{id}")]
        public async Task<TiposHuacalesDTO[]> Get(int id)
        {
            return await entradaHuacalesServices.ListarTipos(t => t.TipoId == id);
        }
    }
}
