using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;
using GenshinFan.Services.Interfaces;

namespace GenshinFan.Services.Implementations;

public class ArmaService : IArmaService
{
    GenshinImpactContext _context;

    public ArmaService(GenshinImpactContext context)
    {
        _context = context;
    }

    public async Task<Arma> Add(Arma arma)
    {
        _context.Armas.Add(arma);
        await _context.SaveChangesAsync();
        return arma;
    }

    public async Task<Arma?> Delete(int id)
    {
        var arma = await _context.Armas.FindAsync(id);
        if (arma == null)
        {
            return null;
        }
        _context.Armas.Remove(arma);
        await _context.SaveChangesAsync();
        return arma;
    }

    public async Task<IEnumerable<Arma>> GetAll()
    {
        return _context.Armas;
    }

    public async Task<Arma?> Get(int id)
    {
        return await _context.Armas.FindAsync(id);
    }

    public async Task<Arma> Update(Arma arma)
    {
        _context.Armas.Update(arma);
        await _context.SaveChangesAsync();
        return arma;
    }

}
