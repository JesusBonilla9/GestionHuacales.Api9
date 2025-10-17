using System.ComponentModel.DataAnnotations;

namespace GestionHuacales.Api9.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }
    public string Descripcion {  get; set; }
    public int Existencias { get; set; }
}
