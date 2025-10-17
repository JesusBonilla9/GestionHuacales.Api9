using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHuacales.Api9.Models;

public class EntradasHuacalesDetalles
{
    [Key]
    public int DetalleId { get; set; }
    public int EntradaId { get; set; }
    public int TipoId { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
}
