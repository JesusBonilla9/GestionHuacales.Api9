using GestionHuacales.Api9.Models;

namespace GestionHuacales.Api9.DTO
{
    public class EntradasHuacalesDTO
    {
        public string NombreCliente { get; set; }
        public EntradaHuacalesDetallesDTO[] Huacales { get; set; } = [];
    }
}
