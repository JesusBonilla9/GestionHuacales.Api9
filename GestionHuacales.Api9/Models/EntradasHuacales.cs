using GestionHuacales.Api9.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHuacales.Api9.Models;

public class EntradasHuacales
{
    [Key]
    public int EntradaId { get; set; }
    [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
    [MaxLength(100)]
    public string NombreCliente { get; set; }
    [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El campo Precio es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public double Importe { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; }

    [ForeignKey(nameof(EntradaId))]
    public virtual ICollection<EntradasHuacalesDetalles> EntradasHuacalesDetalles { get; set; } = new List<EntradasHuacalesDetalles>();
}
