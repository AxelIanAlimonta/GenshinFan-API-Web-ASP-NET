using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan.Services.Implementations
{
    public class ElementoService : IElementoService
    {
        private readonly GenshinImpactContext _context;

        public ElementoService(GenshinImpactContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Elemento>> GetAll()
        {
            return await _context.Elementos.ToListAsync();
        }

        public async Task<Elemento?> Get(int id)
        {
            return await _context.Elementos.FindAsync(id);
        }

        public async Task<Elemento> Add(Elemento elemento)
        {
            _context.Elementos.Add(elemento);
            await _context.SaveChangesAsync();
            return elemento;
        }

        public async Task<Elemento> Update(Elemento elemento)
        {
            _context.Entry(elemento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return elemento;
        }

        public async Task<Elemento?> Delete(int id)
        {
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento != null)
            {
                _context.Elementos.Remove(elemento);
                await _context.SaveChangesAsync();
            }
            return elemento;
        }
    }
}





