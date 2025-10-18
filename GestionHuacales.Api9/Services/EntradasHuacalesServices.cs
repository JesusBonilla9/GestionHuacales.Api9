using GestionHuacales.Api9.DAL;
using GestionHuacales.Api9.DTO;
using GestionHuacales.Api9.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionHuacales.Api9.Services;

public class EntradasHuacalesServices(IDbContextFactory <Contexto> DbFactory) 
{
    public async Task<bool> Guardar(EntradasHuacales Entrada)
    {
        if (!await Existe(Entrada.EntradaId))
        {
            return await Insertar(Entrada);
        }
        else
        {
            return await Modificar(Entrada);
        }
    }
    public async Task<bool> Existe(int EntradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(p => p.EntradaId == EntradaId);
    }
    private async Task<bool> Insertar(EntradasHuacales Entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(Entrada);
        await AfectarHuacales(Entrada.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task AfectarHuacales(EntradasHuacalesDetalles[] detalle, TipoOperacion operacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach(var item in detalle)
        {
            var huacales = await contexto.TiposHuacales.SingleAsync(h => h.TipoId == item.TipoId);
            if (operacion == TipoOperacion.Resta)
                huacales.Existencias -= item.Cantidad;
            else
                huacales.Existencias += item.Cantidad;
            await contexto.SaveChangesAsync();
        }
    }
    private async Task<bool> Modificar(EntradasHuacales Entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var original = await contexto.EntradasHuacales
            .Include(e => e.EntradasHuacalesDetalles)
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.EntradaId == Entrada.EntradaId);

        if (original == null) return false;

        await AfectarHuacales(original.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Resta);

        contexto.EntradasHuacalesDetalles.RemoveRange(original.EntradasHuacalesDetalles);

        contexto.Update(Entrada);

        await AfectarHuacales(Entrada.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Suma);

        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<EntradasHuacales?> Buscar(int EntradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(h => h.EntradasHuacalesDetalles).FirstOrDefaultAsync(p => p.EntradaId == EntradaId);

    }
    public async Task<bool> Eliminar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entrada = await Buscar(idEntrada);

        await AfectarHuacales(entrada.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Resta);
        contexto.EntradasHuacalesDetalles.RemoveRange(entrada.EntradasHuacalesDetalles);
        contexto.EntradasHuacales.Remove(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<EntradasHuacalesDTO[]> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {

        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Where(criterio)
            .Select(h => new EntradasHuacalesDTO
            {
                
                NombreCliente = h.NombreCliente
            })
            .ToArrayAsync();
    }
    public async Task<TiposHuacalesDTO[]> ListarTipos(Expression<Func<TiposHuacales,bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.Where(criterio).Select(t => new TiposHuacalesDTO
        {
            TipoId = t.TipoId,
            Descripcion = t.Descripcion,
            Existencias = t.Existencias
        }).ToArrayAsync();
    }
    public enum TipoOperacion
    {
        Suma = 1,
        Resta = 2
    }
}
