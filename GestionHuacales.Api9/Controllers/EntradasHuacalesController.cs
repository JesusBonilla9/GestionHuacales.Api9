using GestionHuacales.Api9.DTO;
using GestionHuacales.Api9.Models;
using GestionHuacales.Api9.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionHuacales.Api9.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntradasHuacalesController(EntradasHuacalesServices entradaHuacalesServices): ControllerBase
{
    // GET: api/<EntradasHuacalesController>
    [HttpGet]
    public async Task<EntradasHuacalesDTO[]> Get()
    {
        return await entradaHuacalesServices.Listar(l => true);
    }

    // GET api/<EntradasHuacalesController>/5
    [HttpGet("{id}")]
    public async Task<EntradasHuacalesDTO[]>Get(int id)
    {
        return await entradaHuacalesServices.Listar(l => l.EntradaId == id);
    }

    // POST api/<EntradasHuacalesController>
    [HttpPost]
    public async Task Post([FromBody] EntradasHuacalesDTO entradahuacal)
    {
        var entrada = new EntradasHuacales
        {
            Fecha = DateTime.Now,
            NombreCliente = entradahuacal.NombreCliente,
            EntradasHuacalesDetalles = entradahuacal.Huacales.Select(h => new EntradasHuacalesDetalles
            {
                TipoId = h.TipoId,
                Cantidad = h.Cantidad,
                Precio = h.Precio,
            }).ToArray()
        };
        await entradaHuacalesServices.Guardar(entrada);
    }

    // PUT api/<EntradasHuacalesController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] EntradasHuacalesDTO entradahuacal)
    {
        var entrada = new EntradasHuacales
        {
            EntradaId = id,
            Fecha = DateTime.Now,
            NombreCliente = entradahuacal.NombreCliente,
            EntradasHuacalesDetalles = entradahuacal.Huacales.Select(h => new EntradasHuacalesDetalles
            {
                TipoId = h.TipoId,
                Cantidad = h.Cantidad,
                Precio = h.Precio,
            }).ToList()
        };
        await entradaHuacalesServices.Guardar(entrada);
    }

    // DELETE api/<EntradasHuacalesController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await entradaHuacalesServices.Eliminar(id);
    }
}
