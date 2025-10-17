using GestionHuacales.Api9.Models;
using Microsoft.EntityFrameworkCore;
namespace GestionHuacales.Api9.DAL;

public class Contexto : DbContext
{
    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
    public DbSet<TiposHuacales> TiposHuacales { get; set; }
    public DbSet<EntradasHuacalesDetalles> EntradasHuacalesDetalles { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TiposHuacales>().HasData(
            new List<TiposHuacales>()
            {
                new()
                {
                    TipoId = 1,
                    Descripcion = "Rojo Grande",
                },
                new()
                {
                    TipoId = 2,
                    Descripcion = "Rojo Mediano",
                },
                new()
                {
                    TipoId = 3,
                    Descripcion = "Rojo Pequeño",
                },
                new()
                {
                    TipoId = 4,
                    Descripcion = "Verde Grande",
                },
                new()
                {
                    TipoId = 5,
                    Descripcion = "Verde Mediano",
                },
                new()
                {
                    TipoId = 6,
                    Descripcion = "Verde Pequeño",
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
