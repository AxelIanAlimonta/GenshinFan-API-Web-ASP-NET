using System.Collections.Generic;
using System.Threading.Tasks;
using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan.Services.Implementations
{
    public class TipoDeArmaService : ITipoDeArmaService
    {
        private readonly GenshinImpactContext _context;

        public TipoDeArmaService(GenshinImpactContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoDeArma>> GetAll()
        {
            return await _context.TiposDeArma.ToListAsync();
        }

        public async Task<TipoDeArma?> Get(int id)
        {
            return await _context.TiposDeArma.FindAsync(id);
        }

        public async Task<TipoDeArma> Add(TipoDeArma tipoDeArma)
        {
            _context.TiposDeArma.Add(tipoDeArma);
            await _context.SaveChangesAsync();
            return tipoDeArma;
        }

        public async Task<TipoDeArma> Update(TipoDeArma tipoDeArma)
        {
            _context.TiposDeArma.Update(tipoDeArma);
            await _context.SaveChangesAsync();
            return tipoDeArma;
        }

        public async Task<TipoDeArma?> Delete(int id)
        {
            var tipoDeArma = await Get(id);
            if (tipoDeArma == null)
            {
                return null;
            }
            _context.TiposDeArma.Remove(tipoDeArma);
            await _context.SaveChangesAsync();
            return tipoDeArma;
        }
    }
}