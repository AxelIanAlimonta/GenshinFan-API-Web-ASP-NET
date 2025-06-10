using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;
using Microsoft.EntityFrameworkCore;
using GenshinFan.Services.Interfaces;

namespace GenshinFan.Services.Implementations;

public class RegionService : IRegionService
{
    private readonly GenshinImpactContext _context;
    public RegionService(GenshinImpactContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Region>> GetAll()
    {
        return await _context.Regiones.ToListAsync();
    }

    public async Task<Region> Add(Region region)
    {
        _context.Regiones.Add(region);
        await _context.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> Delete(int id)
    {
        var region = await _context.Regiones.FindAsync(id);
        if (region == null)
        {
            return null;
        }
        _context.Regiones.Remove(region);
        await _context.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> Get(int id)
    {
        return await _context.Regiones.FindAsync(id);
    }

    public async Task<Region> Update(Region region)
    {
        var existingRegion = await _context.Regiones.FindAsync(region.Id);
        if (existingRegion == null)
        {
            throw new KeyNotFoundException("Region not found");
        }

        // Actualizar las propiedades de la entidad existente
        existingRegion.Nombre = region.Nombre;
        existingRegion.ImagenURL = region.ImagenURL;

        await _context.SaveChangesAsync();
        return existingRegion;
    }
}
