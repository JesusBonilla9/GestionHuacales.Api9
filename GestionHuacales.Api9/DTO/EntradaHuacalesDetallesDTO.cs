using GestionHuacales.Api9.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionHuacales.Api9.DTO
{
    public class EntradaHuacalesDetallesDTO
    {
        public int TipoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
